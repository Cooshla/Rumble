var express = require('express')
var app = express()

app.set('port', (process.env.PORT || 8000))
app.use(express.static(__dirname + '/public'))
app.use("/lib", express.static(__dirname + '/lib'));
app.use("/data", express.static(__dirname + '/data'));
app.use("/", express.static(__dirname + '/'));

app.get('/', function(request, response) {
  response.sendFile('index.html');
})

app.listen(app.get('port'), function() {
  console.log("Node app is running at localhost:" + app.get('port'))
})
