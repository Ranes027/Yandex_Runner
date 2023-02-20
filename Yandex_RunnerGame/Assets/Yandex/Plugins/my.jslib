mergeInto(LibraryManager.library, {

  Hello: function () {
      window.alert("Hello, world!");
      console.log("Hello, world!");
    },

  PlayerData: function () {
      myGameInstance.SendMessage('Yandex', 'SetName', player.getName());
      myGameInstance.SendMessage('Yandex', 'SetPhoto', player.getPhoto("medium"));
    },

    RateGame: function () {
    
      ysdk.feedback.canReview()
        .then(({ value, reason }) => {
            if (value) {
                ysdk.feedback.requestReview()
                    .then(({ feedbackSent }) => {
                        console.log(feedbackSent);
                    })
            } else {
                console.log(reason)
            }
        })
  },


  SaveExtern: function(data) {
      var dataString = UTF8ToString(data);
      var myobj = JSON.parse(dataString);
      player.setData(myobj);
  },

  LoadExtern: function(){
      player.getData().then(_data => {
          const myJSON = JSON.stringify(_data);
          myGameInstance.SendMessage('Progress', 'SetPlayerInfo', myJSON);
      });
  },

  SetToLeaderboard : function(value){
    ysdk.getLeaderboards()
      .then(lb => {
        lb.setLeaderboardScore('Height', value);
    });
  },

  GetLang : function(){
    var lang = ysdk.environment.i18n.lang;
    var bufferSize = lengthBytesUTF8(lang) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(lang, buffer, bufferSize);
    return buffer;
  },

});