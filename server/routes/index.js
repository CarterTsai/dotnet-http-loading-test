var express = require('express');
var router = express.Router();
var emitEvent = require('../emit');

/* GET home page. */
router.get('/', function(req, res, next) {
  emitEvent.addNum();
  res.render('index', { title: 'Express'});
});

module.exports = router;
