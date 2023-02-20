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

  ShowAdv : function(){
    ysdk.adv.showFullscreenAdv({
    callbacks: {
        onClose: function(wasShown) {
          console.log("Adv closed");
          // some action after close
        },
        onError: function(error) {
          // some action on error
        }
    }
    })
  },

  AddCoinsExtern : function(){
    ysdk.adv.showRewardedVideo({
    callbacks: {
        onOpen: () => {
          console.log('Video ad open.');
        },
        onRewarded: () => {
          console.log('Rewarded!');
          myGameInstance.SendMessage("CollectibleManager", "AddCoins");
        },
        onClose: () => {
          console.log('Video ad closed.');
        }, 
        onError: (e) => {
          console.log('Error while open video ad:', e);
        }
    }
})
  },

});