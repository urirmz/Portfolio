let express = require("express");
let app = express();
let bodyParser = require("body-parser");

console.log("Hello World");

app.use((req, res, next) => {
  console.log(`${req.method} ${req.path} - ${req.ip}`);
  next();
});

app.use(bodyParser.urlencoded({ extended: false }));

app.get("/", (req, res) => {
  res.sendFile(__dirname + "/views/index.html");
});

app.use("/public", express.static(__dirname + "/public"));

app.get("/json", (req, res) => {
  if (process.env.MESSAGE_STYLE == "uppercase") {
    res.json({
      message: "HELLO JSON",
    });
  } else {
    res.json({
      message: "Hello json",
    });
  }
});

app.get(
  "/now",
  (req, res, next) => {
    req.time = new Date().toString();
    next();
  },
  (req, res) => {
    res.json({ time: req.time });
  },
);

app.get("/:word/echo", (req, res) => {
  res.json({ echo: req.params.word });
});

app.get("/name", (req, res) => {
  let firstname = req.query.first;
  let lastname = req.query.last;
  res.json({ name: `${firstname} ${lastname}` });
});

app.post("/name", (req, res) => {
  let firstname = req.body.first;
  let lastname = req.body.last;
  res.json({ name: `${firstname} ${lastname}` });
});

module.exports = app;
