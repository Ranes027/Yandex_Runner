mergeInto(LibraryManager.library, {

  Hello: function () {
    window.alert("Hello, world!");
    console.log("Hello, world!");
  },

  PlayerData: function () {
    myGameInstance.SendMessage('Yandex', 'SetName', player.getName());
    myGameInstance.SendMessage('Yandex', 'SetPhoto', player.getPhoto("medium"));

      console.log(player.getName());
      console.log(player.getPhoto("medium"))
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

  SaveExtern: function (data) {
    var dataString = UTF8ToString(data);
    var myobj = JSON.parse(dataString);
    player setData(myobj);
  },

  LoadExtern: function () {
    player.getData().then(_data => {
      const myJSON = JSON.stringify(_data);
      myGameInstance.SendMessage('Progress', 'SetPlayerInfo', myJSON);
    });
  },

});