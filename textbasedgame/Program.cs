    //----------------------
    //the dictionary
    //----------------------
    List<string> move = ["go", "move", "head", "walk", "run"];
    List<string> left = ["left", "l", "west", "w"];
    List<string> forward = ["forward", "forwards", "f", "north", "n"];
    List<string> right = ["right", "r", "east", "e"];
    List<string> backward = ["backward", "backwards", "b", "south", "s"];
    List<string> examine = ["examine", "look", "check", "survey", "view", "inspect", "scan", "investigate", "audit"];
    List<string> inventory = ["inventory", "bag", "items", "satchel", "pocket", "backpack", "gear", "pack", "pouch", "sack"];
    List<string> use = ["use", "equip", "apply", "hold"];
    List<string> torches = ["torches", "torch", "bundle", "fire", "firesteel", "steel"];
    List<string> surroundings = ["area", "around", "surroundings", "surrounding", "environment", "vicinity", "setting", "space", "zone", "dungeon", "region"];
    List<string> door = ["door", "puzzle", "exit"];
    //again command?
    
    var dictionary = new Dictionary<string, List<string>>() //don't forget to add the lists to this again
    {
        {"move", move},
        {"left", left},
        {"forward", forward},
        {"right", right},
        {"backwards", backward},
        {"examine", examine},
        {"inventory", inventory},
        {"use", use},
        {"torches", torches},
        {"surroundings", surroundings},
        {"door", door},
    };

    var dictionaryVerb = new Dictionary<string, List<string>>()
    {
        {"move", move},
        {"examine", examine},
        {"use", use},
    };

    var dictionarySubject = new Dictionary<string, List<string>>()
    {
        {"left",  left},
        {"forward", forward},
        {"right", right},
        {"backwards", backward},
        {"inventory", inventory},
        {"torches", torches},
        {"surroundings", surroundings},
        {"door", door},
    };
    
    var removeList = new List<string>
    {
        "the", "a", "an", "to", "at", "i", "also", "maybe", "now", "there", "i'll", "gladly", "most", "here", "of", "off", "on",
    };

    var wordList = new List<string>();
    foreach (List<string> list in dictionary.Values)
    {
        wordList.AddRange(list);
    }
    wordList.AddRange(removeList);
    
    if(wordList.Count != wordList.Distinct().Count())
    {
        foreach (string word in wordList)
        {
            Console.WriteLine(word);
        }        
        Console.WriteLine("There are duplicates in the lists!");
    }
    wordList = wordList.Except(removeList).ToList();

    //----------------------
    //the game and required things(/one-time events) in order
    //----------------------
    int area = 0;
    string name = "";
    
    Console.WriteLine("[Welcome.]");
    Thread.Sleep(1000);
    Console.WriteLine("[You will be guiding a loyal man during your time with this game.]");
    Thread.Sleep(1000);
    
    while (String.IsNullOrWhiteSpace(name))
    {
        Console.WriteLine("[What would you like to name your knight?]");
        name = Console.ReadLine() ?? "";
    }
    name = Char.ToUpper(name[0]) + name.Remove(0, 1);

    area = 1;
    
    Console.WriteLine("CHAPTER 1 - THE DARK");
    Thread.Sleep(1000);
    Console.WriteLine(">" + name + " awakens, unable to tell up from down, engulfed by pitch-darkness and a general numbness of the senses.");
    Thread.Sleep(1000);
    Console.WriteLine(">The knight's armour scrapes across the floor as he puts his arm beneath his chest in order to push himself up.");
    Thread.Sleep(1000);
    Console.WriteLine(">His head throbs as he stands up. Although the soles of his sabatons were not plated, he could hardly feel the floor.");
    Thread.Sleep(1000);
    Console.WriteLine("[You may now act.]");

    bool light = false;
    bool doorOpen = false;

    while (!light)
    {
        PlayerInput();
    }
    
    while (!doorOpen)
    {
        PlayerInput();
    }
    
    Console.WriteLine(">The elves must've made this puzzle, given the height of the door, and it's magic nature.");
    Thread.Sleep(1000);
    Console.WriteLine(">As faint light emitted from bioluminescent algae in the next chamber over now illuminates the room, " + name + " extinguishes the torch.");
    Thread.Sleep(1000);
    Console.WriteLine("[You can now enter the second chamber, to your right.]");

    while (area != 2)
    {
        PlayerInput();
    }
    
    Console.WriteLine("end");
    
    //----------------------
    //the games responses to commands
    //----------------------
    void PlayerInput()
    {
        string? playerInput = Console.ReadLine();
        string firstWord = "empty";
        string secondWord = "empty";
        
        if (playerInput != null) //maybe I should remove any repeated spaces too*
        {
            playerInput = playerInput.ToLower();
            foreach (var word in removeList)
            {
                playerInput = playerInput.Replace(word + ' ', "");
            }
            
            firstWord = playerInput.Split(" ")[0];
            
            if (playerInput.Contains(' '))
            {
                secondWord = playerInput.Split(" ")[1];
            }
            else
            {
                secondWord = "";
            }
        }

        if (wordList.Contains(firstWord))
        {
            
            foreach (List<string> list in dictionary.Values)
            {
                if (list.Contains(firstWord))
                {
                    firstWord = dictionary.FirstOrDefault(x => x.Value == list).Key; //the key of the dictionary of which the list is a value
                }
            }
            
            if (wordList.Contains(secondWord))
            {
                foreach (List<string> list in dictionary.Values)
                {
                    if (list.Contains(secondWord))
                    {
                        secondWord = dictionary.FirstOrDefault(x => x.Value == list).Key;
                    }
                }
                
                //swap them if necessary, or shit on grammar * maybe I should add variation to the responses
                if (dictionaryVerb.ContainsKey(firstWord))
                {
                    if (!dictionarySubject.ContainsKey(secondWord)) //1=1 & 2=1, mind the !
                    {
                        Console.WriteLine("[What's with all the verbs?]");
                        return;
                    }
                }
                else
                {
                    if (dictionarySubject.ContainsKey(secondWord)) //1=2 & 2=2
                    {
                        Console.WriteLine("[It's not a sentence without a verb.]");
                        return;
                    }
                    else //1=2 & 2=1
                    {
                        (firstWord, secondWord) = (secondWord, firstWord); //get swapped loser
                    }
                }
            }
            else
            {
                Console.WriteLine("[" + Char.ToUpper(firstWord[0]) + firstWord.Remove(0, 1) + "? Elaborate.]"); //sounds weird when I type e and bro responds with Right?*
                return;
            }
        }
        else
        {
            if (!string.IsNullOrWhiteSpace(firstWord))
            {
                Console.WriteLine("[I don't recognize that first word.]");
            }
            else
            {
                Console.WriteLine("[I'm listening.]");
            }
            return;
        }
        
        //ok we're done with rearranging commands, here's what they actually do
        if (area == 1)
        {
            if (!light)
            {
                if (firstWord == "examine")
                {
                    if (secondWord == "surroundings")
                    {
                        Console.WriteLine(">If there had been no floor to scrape against, the knight would have thought himself dead. He is thankful for his heavy armour.");
                    }
                    if (secondWord == "inventory") //*maybe the inventory should be a list
                    {
                        Console.WriteLine(">Bundle of torches and a fire steel");
                    }
                }
                else if (firstWord == "use")
                {
                    if (secondWord == "torches")
                    {
                        Console.WriteLine(">Normally a fire steel would be used to light tinder, not a torch, but for now it'll have to do.");
                        Thread.Sleep(1000);
                        Console.WriteLine(">After a few sparks had flown, one of the torches ignited. The flame's warmth gives the knight a glimmer of comfort.");
                        Thread.Sleep(1000);
                        Console.WriteLine(">Stone comes into view all around him. To his left there seems to be an entrance to this room. It has collapsed, and the dust that must have created has settled onto the floor and rubble.");
                        Thread.Sleep(1000);
                        Console.WriteLine(">On the right is a closed door, seemingly locked with a puzzle.");
                        Thread.Sleep(1000);
                        Console.WriteLine(">Between these two doors there have not formed any stalagmites, but the edges of the room are marred by them.");
                        light = true;
                    }
                }
                else
                {
                    Console.WriteLine(">The knight decides it's best to avoid doing anything that will not help illuminate the area, lest he hurt himself.");
                }
            }
            else
            {
                if (!doorOpen)
                {
                    if (firstWord == "move")
                    {
                        if (secondWord == "backward" || secondWord == "forward")
                        {
                            Console.WriteLine(">" + name + " knows the stalagmites are not as sharp as they look in this dimly lit cave, however, he would prefer not to disturb their centuries of growth.");
                        }
                        if (secondWord == "left")
                        {
                            Console.WriteLine(">He stirs some of the dust. As some of the particles float down again, they land in the moist areas on either side of the door and seemingly merge into the floor.");
                            Thread.Sleep(1000);
                            Console.WriteLine(">There's too much rubble to move on his own.");
                        }
                        if (secondWord == "right")
                        {
                            Console.WriteLine(">The door is closed, and no matter how " + name + " strains himself, he cannot force it open.");
                        }
                    }
                    else if (firstWord == "examine")
                    {
                        if (secondWord == "door") //*bug
                        {
                            Console.WriteLine(">A door has been carved out of the cavern wall, it has three engraved panels embedded into its header.");
                            Thread.Sleep(1000);
                            Console.WriteLine(">The first design depicts an egg, the second an hourglass, and the last a snake eating its own tail.");
                            Thread.Sleep(1000);
                            Console.WriteLine("[Which panel would you like to press?]");

                            while (!doorOpen)
                            {
                                string? input = Console.ReadLine()?.ToLower();
                                if (input == "l" || input == "left" || input == "egg" || input == "first" || input == "1")
                                {
                                    Console.WriteLine("[And the next one?]");
                                    input = Console.ReadLine()?.ToLower();
                                    
                                    if (input == "r" || input == "right" || input == "snake" || input == "last" || input == "3" || input == "ouroboros")
                                    {
                                        Console.WriteLine(">The second panel buries itself into the wall.");
                                        Thread.Sleep(1000);
                                        Console.WriteLine(">The knight nudges the last panel, and as it vanishes out of sight, the door slides open.");
                                        doorOpen = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine(">Both pressed panels re-emerged from the wall.");
                                        Thread.Sleep(1000);
                                        Console.WriteLine("[Which panel would you like to push first this time?]");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(">The panel sunk into the wall, but reappeared just as quickly.");
                                    Thread.Sleep(1000);
                                    Console.WriteLine("[Which panel would you like to push first this time?]");
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine(">" + name + " believes that won't help him escape the cavern.");
                        Thread.Sleep(1000);
                        Console.WriteLine(">Oxygen might be in limited supply, after all.");
                    }
                }
                else
                {
                    if (firstWord == "move")
                    {
                        if (secondWord == "backward" || secondWord == "forward")
                        {
                            Console.WriteLine(">Now that they are illuminated by blue light from the algae, the stalagmites resemble distant pine trees.");
                            Thread.Sleep(1000);
                            Console.WriteLine(">The knight sees no reason to wade through them.");
                        }
                        if (secondWord == "left")
                        {
                            Console.WriteLine("[The door you just opened is on the other side.]");
                        }
                        if (secondWord == "right")
                        {
                            Console.WriteLine(">He carefully moves through the door.");
                            area = 2;
                        }
                    }
                    else if (firstWord == "examine")
                    {
                        if (secondWord == "door")
                        {
                            Console.WriteLine(">It's open. Because of the blue light, he'd almost think it leads outside.");
                        }
                    }
                    else
                    {
                        Console.WriteLine(">It's best to move on to the next chamber.");
                    }
                }
            }
        }
    }