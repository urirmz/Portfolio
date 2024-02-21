const express = require('express')
const app = express()
const cors = require('cors')
const bodyParser = require("body-parser");
const mongoose = require('mongoose');
const { acceptsLanguage } = require('express/lib/request');
require('dotenv').config()

mongoose.connect(process.env.MONGO_URI);

const userSchema = new mongoose.Schema({ 
  username: { type: String, required: true }
});
const User = mongoose.model("users", userSchema);

const excersiseSchema = new mongoose.Schema({ 
  user: { 
          $ref: String, 
          $id: String 
        },
  description: { type: String, required: true },
  duration: { type: Number, required: true },
  date: String
});
const Excersise = mongoose.model("excersises", excersiseSchema);

app.use(bodyParser.urlencoded({ extended: false }));

app.use(cors())
app.use(express.static('public'))
app.get('/', (req, res) => {
  res.sendFile(__dirname + '/views/index.html')
});

const listener = app.listen(process.env.PORT || 3000, () => {
  console.log('Your app is listening on port ' + listener.address().port)
});

app.post("/api/users/", async (req, res) => {
  let userRegistered = await User.findOne({ username: req.body.username });
  if (!userRegistered) {
    let newUser = new User({ username: req.body.username });
    userRegistered = await newUser.save();
  }
  res.json({ username: userRegistered.username, _id: userRegistered._id});
});

app.get("/api/users/", async (req, res) => {
  let allUsers = await User.find();
  res.json(allUsers);
})

app.post("/api/users/:_id/exercises", async (req, res) => {
  let date;
  if (req.body.date) 
    { date = new Date(req.body.date); } 
  else 
    { date = new Date(Date.now()); }

  let newExcersise = new Excersise({
    user: { $ref: "users", $id: req.params._id },
    description: req.body.description,
    duration: req.body.duration,
    date: date.toDateString(),
  });

  let excersiseRegistered = await newExcersise.save();
  let user = await User.findOne({ _id: excersiseRegistered.user.$id });
  
  res.json({
    username: user.username,
    description: excersiseRegistered.description,
    duration: excersiseRegistered.duration,
    date: excersiseRegistered.date,
    _id: excersiseRegistered.user.$id
  });
})

app.get("/api/users/:id/logs", async (req, res) => {
  userExcersiseLogs = await Excersise.find({ "user.$id" : req.params.id });
  res.json({ userExcersiseLogs });
});