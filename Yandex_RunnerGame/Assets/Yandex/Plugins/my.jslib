mergeInto(LibraryManager.library, {

  Hello: function () {
    window.alert("Hello, world!");
    console.log("Hello, world!");
  },

PlayerData: function () {
  MyGameInstance.SendMessage('Yandex', 'SetName', player.getName());
  MyGameInstance.SendMessage('Yandex', 'SetPhoto', player.getPhoto("medium"));

    console.log(player.getName());
    console.log(player.getPhoto("medium"))
  },

});