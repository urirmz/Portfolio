require('dotenv').config();
const express = require('express');
const cors = require('cors');
const app = express();
const bodyParser = require("body-parser");
const dns = require('dns');
const { doesNotMatch } = require('assert');
const { error } = require('console');
const res = require('express/lib/response');
const mongoose = require('mongoose');

mongoose.connect(process.env.MONGO_URI);

const urlSchema = new mongoose.Schema({ 
  originalUrl: { type: String, required: true },
  shortUrl: { type: Number, required: true }
});
const urlDoc = mongoose.model("Url", urlSchema);

const errorMessage = { error: 'invalid url' };

app.use(bodyParser.urlencoded({ extended: false }));

// Basic Configuration
const port = process.env.PORT || 3000;

app.use(cors());

app.use('/public', express.static(`${process.cwd()}/public`));

app.get('/', function(req, res) {
  res.sendFile(process.cwd() + '/views/index.html');
});

// Your first API endpoint
app.get('/api/hello', function(req, res) {
  res.json({ greeting: 'hello API' });
});

app.listen(port, function() {
  console.log(`Listening on port ${port}`);
});

app.post('/api/shorturl', async (req, res) => {
  let urlObject; try {
    urlObject = new URL(req.body.url);
  } catch {
    return res.json(errorMessage);
  }
  
  url = req.body.url;

  let urlDocFound = await urlDoc.findOne({ originalUrl: url }).exec();
  
  if (urlDocFound) {
    return res.json({ original_url : url, short_url : urlDocFound.shortUrl });
  } else {
    dns.lookup(urlObject.hostname, async (error) => {
      if (error) { 
        return res.json(errorMessage);
      } else {
        let currentMaxShortUrl = await urlDoc.findOne().sort({ shortUrl: -1 }).exec();
        let newShortUrl;
        if (currentMaxShortUrl) {
          newShortUrl = currentMaxShortUrl.shortUrl + 1;
        } else {
          newShortUrl = 1;
        }
        let newUrlDoc = new urlDoc({ originalUrl: url, shortUrl: newShortUrl});
        let saveResult = await newUrlDoc.save();
        return res.json({ original_url : url, short_url : saveResult.shortUrl });
      }
    });
  }
})

app.get('/api/shorturl/:shortUrl', async (req, res) => {
  let validUrl = await urlDoc.findOne({ shortUrl: req.params.shortUrl });
  if (validUrl) {
    return res.redirect(validUrl.originalUrl);
  } else {
    return res.json(errorMessage);
  }
})

