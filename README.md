# Rock Paper Scissors

__An ASP.Net MVC implementation of the game "Rock Paper Scissors"__ 

Write an application that lets you play Rock-Paper-Scissors according to this criteria:

* I can play Player vs Computer 
* I can play Computer vs Computer
* I can play a different game each time
* Write a scaled-down version (think minimum viable product), small and well crafted
* Write the application with high unit test coverage and well factored code

Technical Constraints/Considerations
                                                  
* Doesn't necessarily need a flashy GUI (can be simple)                                
* Use .NET toolset (i.e. c#) and any associated plug ins you see fit 			   
* Use best industry practices

Don't know the game? http://en.wikipedia.org/wiki/Rock-paper-scissors

Things to improve from the current version (commit num.8)
                                                  
* The UI does not maintain the state of the last played game's selected settings just yet. This is particularly noticeable when trying to play a Computer vs Computer game various times in a row. But the required data to cater for this is already contained within the view model so it shouldn't be difficult to implement this         
* The UI has duplicated code on the views that should be moved into shared partial views to reduce code duplication 			   
* The UI doesn't look great at the moment but still fullfills the criteria of a viable working game
* More tests could be written for various parts of the web project
