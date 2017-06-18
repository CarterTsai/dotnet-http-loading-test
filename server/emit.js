
var io = {};
var num = 0;
var attack = {};
module.exports = {
    init: function(server) {
        io = require('socket.io')(server);
        io.on('connection', function(socket){ 
            console.log('a user connected');
            socket.on('total', function(){
                io.emit('total', attack);
            });
        });
    },
    addNum: function () {
        num++;
        attack  = {
            num : num,
            datetime: "2016/06/01"
        }
        io.emit('total', attack);
    }
}