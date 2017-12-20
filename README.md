# PSN.NET
.NET API for Playstation Network Store fetching

This simple library wraps Playstation Store Chihiro API in .NET Standard.

Client Usage:
```c#
  var client = new ChihiroAPIClient();
  PSNItem game = client.GetItem("UP9000-NPUA80636_00-GOWGHOSTOFSPARTA", "US", "20");
  Console.WriteLine(game.TitleName);
```
  Will fetch and return game title from the store.
  
For PSNItem properties refer to [GameItem](!https://github.com/FaithLV/PSN.NET/blob/master/PSN.NET/PSNGameItem.cs) object.
