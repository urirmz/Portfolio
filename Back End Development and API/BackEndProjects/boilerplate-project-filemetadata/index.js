require('dotenv').config()
var express = require('express');
var cors = require('cors');
var fs = require('fs');
var multer = require('multer');

const upload = multer({ dest: 'storage/' });

var app = express();

app.use(cors());
app.use('/public', express.static(process.cwd() + '/public'));

app.get('/', function (req, res) {
  res.sendFile(process.cwd() + '/views/index.html');
});

app.post('/api/fileanalyse', upload.single('upfile'),
  (req, res, next) => {
    next();
  }, 
  (req, res) => {
    let name = req.file.originalname;
    let type = req.file.mimetype;
    let size = req.file.size;

    try {
      fs.unlinkSync(req.file.path);
    } catch (err) {
      console.error(err);
    }

    res.json({ name : name, type : type, size : size });
  }
);

const port = process.env.PORT || 3000;
app.listen(port, function () {
  console.log('Your app is listening on port ' + port)
});
