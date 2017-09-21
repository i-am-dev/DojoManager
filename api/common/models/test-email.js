'use strict';

module.exports = function(Testemail) {
    Testemail.greet = function(msg, cb) {
        Testemail.app.models.Email.send({
            to: "richard@electro.tk",
            from: "fron@from.com",
            subject: msg,
            text: "text message",
            html: "html <b>message</b>"
        })
        .then(function(response){
            console.log(response);
            Testemail.app.models.EmailDB.create({
                "sentTo": "richard@electro.tk",
                "sentFrom": "fron@from.com",
                "emailSubject": msg,
                "emailBody": "html <b>message</b>",
                "sentDt": new Date(),
                "mailgunMessageId": response.id,
                "wasSent": true
            }, function(err, models){
                if(err) console.log(err)
                if(models) console.log(models)
            });
            cb(null, 'Greetings... Email sent');
        })
        .catch(function(err){
            console.log(err);
            cb(null, 'Greetings... Email failed');
        });
        
      }
  
      Testemail.remoteMethod('greet', {
            accepts: {arg: 'msg', type: 'string'},
            returns: {arg: 'greeting', type: 'string'}
      });
};
