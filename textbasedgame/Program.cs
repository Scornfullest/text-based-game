    //----------------------
    //the dictionary
    //----------------------
    List<string> go = new List<string>
    {
        "go", "move", "head", "walk", "run",
    };
    
    List<string> left = new List<string>
    {
        "left", "l", "west", "w",
    };
    
    List<string> forward = new List<string>
    {
        "forward", "forwards", "f", "north", "n",
    };
    
    List<string> right = new List<string>
    {
        "right", "r", "east", "e",
    };
    
    List<string> backward = new List<string>
    {
        "backward", "backwards", "b", "south", "s",
    };

    List<string> examine = new List<string>
    {
        "examine", "look", "check", "survey", "view", "inspect", "scan", "investigate", "audit",
    };

    List<string> inventory = new List<string>
    {
        "inventory", "bag", "items", "satchel", "pocket", "backpack", "gear", "pack", "pouch", "sack", 
    };

    List<string> use = new List<string>
    {
        "use", "equip", "apply", "hold",
    };

    List<string> torches = new List<string>
    {
        "torches", "torch", "bundleoftorchesandafiresteel", "bundle", "fire", "firesteel", "steel", "torchesandfiresteel", "torchesandsteel", "bundleoftorches",
    };

    List<string> surroundings = new List<string>()
    {
        "area", "around", "surroundings", "surrounding", "environment", "vicinity", "setting", "space", "zone", "dungeon", "region",
    };

    var dictionary = new Dictionary<string, List<string>>() //don't forget to add the lists to this again
    {
        {"go", go},
        {"left", left},
        {"forwards", forward},
        {"right", right},
        {"backwards", backward},
        {"examine", examine},
        {"inventory", inventory},
        {"use", use},
        {"torches", torches},
        {"surroundings", surroundings},
    };

    var dictionaryVerb = new Dictionary<string, List<string>>()
    {
        {"go", go},
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
    Console.WriteLine("[You will be guiding a loyal man during your time with this game.]");
    
    while (String.IsNullOrWhiteSpace(name))
    {
        Console.WriteLine("[What would you like to name your knight?]");
        name = Console.ReadLine() ?? "";
    }
    name = Char.ToUpper(name[0]) + name.Remove(0, 1);

    area = 1;
    
    Console.WriteLine("CHAPTER 1 - THE DARK");
    Console.WriteLine(">" + name + " awakens, unable to tell up from down, engulfed by pitch-darkness and a general numbness of the senses.");
    Console.WriteLine(">The knight's armour scrapes across the floor as he puts his arm beneath his chest in order to push himself up.");
    Console.WriteLine(">His head throbs as he stands up. Although the soles of his sabatons were not plated, he could hardly feel the floor.");
    Console.WriteLine("[You may now act.]");

    bool light = false;

    while (!light)
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
        
        if (playerInput != null)
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
                
                //swap them if necessary, or shit on grammar
                if (dictionaryVerb.ContainsKey(firstWord))
                {
                    if (!dictionarySubject.ContainsKey(secondWord)) //1=1 & 2=1, mind the !
                    {
                        Console.WriteLine("[What's with all the verbs?]");
                    }
                }
                else
                {
                    if (dictionarySubject.ContainsKey(secondWord)) //1=2 & 2=2
                    {
                        Console.WriteLine("[It's not a sentence without a verb.]");
                    }
                    else //1=2 & 2=1
                    {
                        (firstWord, secondWord) = (secondWord, firstWord); //get swapped loser
                    }
                }
            }
            else
            {
                Console.WriteLine("[" + Char.ToUpper(firstWord[0]) + firstWord.Remove(0, 1) + "? Elaborate.]");
                return;
            }
        }
        else
        {
            Console.WriteLine("[I don't recognize that first word.]"); //if I type (thing) + use it says this too*
            return;
        }
        
        //ok we're done with rearranging commands, here's what they actually do
        
        if (area == 1)
        {
            if (!light)
            {
                if (firstWord == "")
                {
                    if (secondWord == "")
                    {
                        Console.WriteLine("");
                    }
                }
                else if (firstWord == "")
                {
                }
            }
            else
            {
                if (firstWord == "")
                {
                    if (secondWord == "")
                    {
                        Console.WriteLine("");
                    }
                }
            }
        }

        Thread.Sleep(1000);
    }