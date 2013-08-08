﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgrammingChallenge_II;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ProgrammingChallenge_II
{
    public class Player_Solution
    {

        private Map gamemap;
        private int indexOfHomePlayer;
        private Communicator com;
        private Player home;
        private int mapSize;
        private Player[] players;
        private List<Item> coin;
        private List<Item> life;
        private int attack_floow_switch;
        public Player_Solution(Map map) {

            this.gamemap = map;
            this.indexOfHomePlayer = map.getIndexOfHomePlayer();
            com = new Communicator();
            home = gamemap.getPlayerByIndex(this.indexOfHomePlayer);
            mapSize = gamemap.getMapSize();
            players = gamemap.getAllPlayers();
            coin = gamemap.getCoinPiles();
            life = gamemap.getLifepacks();
            this.attack_floow_switch = 0;
           
                
        }
        
       
        public void stear() {


                com = new Communicator();

                players = gamemap.getAllPlayers();
                coin = gamemap.getCoinPiles();
                life = gamemap.getLifepacks();
                int x_current = players[this.indexOfHomePlayer].getCoordinates().getXCoordinate();
                int y_current = players[this.indexOfHomePlayer].getCoordinates().getYCoordinate();
                Console.WriteLine("X:" + players[this.indexOfHomePlayer].getCoordinates().getXCoordinate());
                Console.WriteLine("Y:" + players[this.indexOfHomePlayer].getCoordinates().getYCoordinate()); 
                int max = 40;
                int x_target;
                int y_target;
               // int closestPlayerindex = 0;
                int closestCoinpileIndex=0;
                int closestLifepackIndex = 0;
               
            /*
               for (int i = 0; i < players.Length; i++)
                {

                    if (i != this.indexOfHomePlayer & players[i].isAlive())
                    {
                        x_target = players[i].getCoordinates().getXCoordinate();
                        y_target = players[i].getCoordinates().getYCoordinate();
                        if (max >=this.utilityFunction(x_target, y_target, x_current, y_current))
                        {
                            max = this.utilityFunction(x_target, y_target, x_current, y_current);
                            closestPlayerindex = i;
                        }
                    }

                }*/

                
                // while (coin.Count == 0) ;


                if (coin.Count != 0 && gamemap.getNumberOfAliveCoinPilies()!=0)
                {

                    if (players[this.indexOfHomePlayer].getHealth() <= 50 && gamemap.getNumberOfAliveLifePacks() != 0) {

                        for (int i = 0; i < life.Count; i++) {
                            Console.WriteLine("Life Pack alive:" + life.ElementAt(i).isAlive() +"   "+life.ElementAt(i).getCoordinates().getCoordinatesAsAString());
                            if (life.ElementAt(i).isAlive()) {
                                x_target = life.ElementAt(i).getCoordinates().getXCoordinate();
                                y_target = life.ElementAt(i).getCoordinates().getYCoordinate();
                                if (max >= this.utilityFunction(x_target, y_target, x_current, y_current))
                                {
                                    max = this.utilityFunction(x_target, y_target, x_current, y_current);
                                    closestLifepackIndex = i;
                                }
                             }
                        
                        }

                        x_target = life.ElementAt(closestLifepackIndex).getCoordinates().getXCoordinate();
                        y_target = life.ElementAt(closestLifepackIndex).getCoordinates().getYCoordinate();
                    
                    
                    }else{

                        for (int i = 0; i < coin.Count; i++)
                        {

                            Console.WriteLine("Coin Pile alive:" + coin.ElementAt(i).isAlive());

                            if (coin.ElementAt(i).isAlive())
                            {

                                x_target = coin.ElementAt(i).getCoordinates().getXCoordinate();
                                y_target = coin.ElementAt(i).getCoordinates().getYCoordinate();
                                if (max >= this.utilityFunction(x_target, y_target, x_current, y_current))
                                {
                                    max = this.utilityFunction(x_target, y_target, x_current, y_current);
                                    closestCoinpileIndex = i;
                                }

                            }
                        }



                        x_target = coin.ElementAt(closestCoinpileIndex).getCoordinates().getXCoordinate();
                        y_target = coin.ElementAt(closestCoinpileIndex).getCoordinates().getYCoordinate();
                }

                    int[] utilityValues = { -1, -1, -1, -1 };
                    x_current = players[this.indexOfHomePlayer].getCoordinates().getXCoordinate();
                    y_current = players[this.indexOfHomePlayer].getCoordinates().getYCoordinate();

                    if (x_current + 1 < this.mapSize)
                    {
                        if (gamemap.getCell(x_current + 1, y_current).Equals("Empty") || gamemap.getCell(x_current + 1, y_current).Split('_')[0].Equals("C") || gamemap.getCell(x_current + 1, y_current).Split('_')[0].Equals("L") || gamemap.getCell(x_current + 1, y_current).Split('_')[0].Equals("P"))
                        {
                            if (gamemap.getCell(x_current + 1, y_current).Split('_')[0].Equals("P"))
                            {
                                //this.attack();
                                utilityValues[0] = this.utilityFunction(x_target, y_target, x_current + 1, y_current);
                            }
                            else
                            {
                                //com.sendMessage_ToServer("RIGHT#");
                                utilityValues[0] = this.utilityFunction(x_target, y_target, x_current + 1, y_current);
                                Console.WriteLine("RIGHT :" + utilityValues[0]);

                            }
                        }
                        Console.WriteLine(gamemap.getCell(x_current + 1, y_current));

                    }
                    x_current = players[this.indexOfHomePlayer].getCoordinates().getXCoordinate();
                    y_current = players[this.indexOfHomePlayer].getCoordinates().getYCoordinate();

                    if (y_current + 1 < this.mapSize)
                    {
                        if (gamemap.getCell(x_current, y_current + 1).Equals("Empty") || gamemap.getCell(x_current, y_current + 1).Split('_')[0].Equals("C") || gamemap.getCell(x_current, y_current + 1).Split('_')[0].Equals("L") || gamemap.getCell(x_current, y_current + 1).Split('_')[0].Equals("P"))
                        {
                            if (gamemap.getCell(x_current, y_current + 1).Split('_')[0].Equals("P"))
                            {
                                //this.attack();
                                utilityValues[1] = this.utilityFunction(x_target, y_target, x_current, y_current + 1);
                            }
                            else
                            {
                                //com.sendMessage_ToServer("DOWN#");
                                utilityValues[1] = this.utilityFunction(x_target, y_target, x_current, y_current + 1);
                                Console.WriteLine("DOWN: " + utilityValues[1]);


                            }

                        }
                        Console.WriteLine(gamemap.getCell(x_current, y_current + 1));
                    }
                    x_current = players[this.indexOfHomePlayer].getCoordinates().getXCoordinate();
                    y_current = players[this.indexOfHomePlayer].getCoordinates().getYCoordinate();

                    if (x_current - 1 >= 0)
                    {
                        if (gamemap.getCell(x_current - 1, y_current).Equals("Empty") || gamemap.getCell(x_current - 1, y_current).Split('_')[0].Equals("C") || gamemap.getCell(x_current - 1, y_current).Split('_')[0].Equals("L") || gamemap.getCell(x_current - 1, y_current).Split('_')[0].Equals("P"))
                        {
                            if (gamemap.getCell(x_current - 1, y_current).Split('_')[0].Equals("P"))
                            {
                                //this.attack();
                                utilityValues[2] = this.utilityFunction(x_target, y_target, x_current - 1, y_current);
                            }
                            else
                            {
                                //com.sendMessage_ToServer("LEFT#");
                                utilityValues[2] = this.utilityFunction(x_target, y_target, x_current - 1, y_current);
                                Console.WriteLine("Left " + utilityValues[2]);

                            }

                        }
                        Console.WriteLine(gamemap.getCell(x_current - 1, y_current));
                    }
                    x_current = players[this.indexOfHomePlayer].getCoordinates().getXCoordinate();
                    y_current = players[this.indexOfHomePlayer].getCoordinates().getYCoordinate();

                    if (y_current - 1 >= 0)
                    {
                        if (gamemap.getCell(x_current, y_current - 1).Equals("Empty") || gamemap.getCell(x_current, y_current - 1).Split('_')[0].Equals("C") || gamemap.getCell(x_current, y_current - 1).Split('_')[0].Equals("L") || gamemap.getCell(x_current, y_current - 1).Split('_')[0].Equals("P"))
                        {
                            if (gamemap.getCell(x_current, y_current - 1).Split('_')[0].Equals("P"))
                            {
                                //this.attack();
                                utilityValues[3] = this.utilityFunction(x_target, y_target, x_current, y_current - 1);
                            }
                            else
                            {
                                //com.sendMessage_ToServer("UP#");
                                utilityValues[3] = this.utilityFunction(x_target, y_target, x_current, y_current - 1);
                                Console.WriteLine("Up " + utilityValues[3]);

                            }

                        }
                        Console.WriteLine(gamemap.getCell(x_current, y_current - 1));
                    }


                    int bestMove = -1;
                    int min = 40;
                    //  Boolean state = false;
                    for (int i = 0; i < utilityValues.Length; i++)
                    {
                        if (utilityValues[i] != -1 && min >= utilityValues[i])
                        {
                            min = utilityValues[i];
                            bestMove = i;

                        }
                    }


                    switch (bestMove)
                    {

                        case 0: com.sendMessage_ToServer("RIGHT#");
                            Console.WriteLine("CHOOSED MOVE: RIGHT");
                            break;
                        case 1: com.sendMessage_ToServer("DOWN#");
                            Console.WriteLine("CHOOSED MOVE: DOWN");
                            break;
                        case 2: com.sendMessage_ToServer("LEFT#");
                            Console.WriteLine("CHOOSED MOVE: LEFT");
                            break;
                        case 3: com.sendMessage_ToServer("UP#");
                            Console.WriteLine("CHOOSED MOVE: UP");
                            break;
                        default: com.sendMessage_ToServer("SHOOT#");
                            Console.WriteLine("CHOOSED MOVE: SHOOT");
                            break;
                    }



                }
                else {
                    if (this.attack_floow_switch <= 1)
                    {
                        this.follow_attack();
                        this.attack_floow_switch++;
                    }
                    else {
                        if (!this.attack()) {
                            this.attack_floow_switch = 0;
                        }
                    }

                }
            
        
        
        
        }

        public bool attack() {

            int x_home;
            int y_home;
            int direction;
            int x_target, y_target;
            bool state = false;
            x_home = players[indexOfHomePlayer].getCoordinates().getXCoordinate();
            y_home = players[indexOfHomePlayer].getCoordinates().getYCoordinate();
        
            direction=players[indexOfHomePlayer].getDirection();
            
            for (int i = 0; i < players.Length; i++) {
                x_target = players[i].getCoordinates().getXCoordinate();
                y_target = players[i].getCoordinates().getYCoordinate();
                
                if (i != indexOfHomePlayer && (x_home ==x_target || y_home==y_target) && players[i].isAlive()) {
                   // state = true;
                    if (x_home == x_target){
                        
                        if (this.X_direct(y_home, y_target, x_home)) {
                            state = true;
                            if (y_home > y_target)
                            {
                                if (direction != 0)
                                {
                                    com = new Communicator();
                                    com.sendMessage_ToServer("UP#");
                                    return state;
                                    
                                }
                            }
                            else {

                                if (direction != 2) {
                                    com = new Communicator();
                                    com.sendMessage_ToServer("DOWN#");
                                    return state;
                                    
                                }
                            
                            }

                          
                                com = new Communicator();
                                com.sendMessage_ToServer("SHOOT#");
                                Console.WriteLine("Shooting.........");
                                
                        }
                        


                    }
                    else if(y_home==y_target){

                        if (this.Y_diect(x_home, x_target, y_home)) {
                            state = true;
                            if (x_home > x_target)
                            {

                                if (direction != 3)
                                {
                                    com = new Communicator();
                                    com.sendMessage_ToServer("LEFT#");
                                    return state;
                                }

                            }
                            else {

                                if (direction != 1) {
                                    com = new Communicator();
                                    com.sendMessage_ToServer("RIGHT#");
                                    return state;
                                     
                                }

                            
                            }

                           
                                com = new Communicator();
                                com.sendMessage_ToServer("SHOOT#");
                                Console.WriteLine("Shooting.........");
                               
                            
                        
                        }


                        
                    } 

                }
            }

            return state;
         
        }

        public void follow_attack() {

            int x_target;
            int y_target;
            int max = 40;
            int closestPlayerindex = -1;
            int x_current = players[this.indexOfHomePlayer].getCoordinates().getXCoordinate();
            int y_current = players[this.indexOfHomePlayer].getCoordinates().getYCoordinate();

            for (int i = 0; i < players.Length; i++)
            {

                if (i != this.indexOfHomePlayer & players[i].isAlive())
                {
                    x_target = players[i].getCoordinates().getXCoordinate();
                    y_target = players[i].getCoordinates().getYCoordinate();
                    if (max >= this.utilityFunction(x_target, y_target, x_current, y_current))
                    {
                        max = this.utilityFunction(x_target, y_target, x_current, y_current);
                        closestPlayerindex = i;
                    }
                }

            }

            if (closestPlayerindex != -1) {

                x_target = players[closestPlayerindex].getCoordinates().getXCoordinate();
                y_target = players[closestPlayerindex].getCoordinates().getYCoordinate();

                int[] utilityValues = { -1, -1, -1, -1 };
                x_current = players[this.indexOfHomePlayer].getCoordinates().getXCoordinate();
                y_current = players[this.indexOfHomePlayer].getCoordinates().getYCoordinate();

                if (x_current + 1 < this.mapSize)
                {
                    if (gamemap.getCell(x_current + 1, y_current).Equals("Empty") || gamemap.getCell(x_current + 1, y_current).Split('_')[0].Equals("C") || gamemap.getCell(x_current + 1, y_current).Split('_')[0].Equals("L") || gamemap.getCell(x_current + 1, y_current).Split('_')[0].Equals("P"))
                    {
                        if (gamemap.getCell(x_current + 1, y_current).Split('_')[0].Equals("P"))
                        {
                          //  this.attack(); 
                           
                        }
                        else
                        {
                            //com.sendMessage_ToServer("RIGHT#");
                            utilityValues[0] = this.utilityFunction(x_target, y_target, x_current + 1, y_current);
                            Console.WriteLine("RIGHT :" + utilityValues[0]);
                          //  this.attack();
                            
                        }
                    }
                    Console.WriteLine(gamemap.getCell(x_current + 1, y_current));

                }
                x_current = players[this.indexOfHomePlayer].getCoordinates().getXCoordinate();
                y_current = players[this.indexOfHomePlayer].getCoordinates().getYCoordinate();

                if (y_current + 1 < this.mapSize)
                {
                    if (gamemap.getCell(x_current, y_current + 1).Equals("Empty") || gamemap.getCell(x_current, y_current + 1).Split('_')[0].Equals("C") || gamemap.getCell(x_current, y_current + 1).Split('_')[0].Equals("L") || gamemap.getCell(x_current, y_current + 1).Split('_')[0].Equals("P"))
                    {
                        if (gamemap.getCell(x_current, y_current + 1).Split('_')[0].Equals("P"))
                        {
                           // this.attack();
                            
                        }
                        else
                        {
                            //com.sendMessage_ToServer("DOWN#");
                            utilityValues[1] = this.utilityFunction(x_target, y_target, x_current, y_current + 1);
                            Console.WriteLine("DOWN: " + utilityValues[1]);
                            //this.attack();
                          
                        }

                    }
                    Console.WriteLine(gamemap.getCell(x_current, y_current + 1));
                }
                x_current = players[this.indexOfHomePlayer].getCoordinates().getXCoordinate();
                y_current = players[this.indexOfHomePlayer].getCoordinates().getYCoordinate();

                if (x_current - 1 >= 0)
                {
                    if (gamemap.getCell(x_current - 1, y_current).Equals("Empty") || gamemap.getCell(x_current - 1, y_current).Split('_')[0].Equals("C") || gamemap.getCell(x_current - 1, y_current).Split('_')[0].Equals("L") || gamemap.getCell(x_current - 1, y_current).Split('_')[0].Equals("P"))
                    {
                        if (gamemap.getCell(x_current - 1, y_current).Split('_')[0].Equals("P"))
                        {
                           // this.attack();
                            
                        }
                        else
                        {
                            //com.sendMessage_ToServer("LEFT#");
                            utilityValues[2] = this.utilityFunction(x_target, y_target, x_current - 1, y_current);
                            Console.WriteLine("Left " + utilityValues[2]);
                            //this.attack();
                           
                        }

                    }
                    Console.WriteLine(gamemap.getCell(x_current - 1, y_current));
                }
                x_current = players[this.indexOfHomePlayer].getCoordinates().getXCoordinate();
                y_current = players[this.indexOfHomePlayer].getCoordinates().getYCoordinate();

                if (y_current - 1 >= 0)
                {
                    if (gamemap.getCell(x_current, y_current - 1).Equals("Empty") || gamemap.getCell(x_current, y_current - 1).Split('_')[0].Equals("C") || gamemap.getCell(x_current, y_current - 1).Split('_')[0].Equals("L") || gamemap.getCell(x_current, y_current - 1).Split('_')[0].Equals("P"))
                    {
                        if (gamemap.getCell(x_current, y_current - 1).Split('_')[0].Equals("P"))
                        {
                           // this.attack();
                          
                        }
                        else
                        {
                            //com.sendMessage_ToServer("UP#");
                            utilityValues[3] = this.utilityFunction(x_target, y_target, x_current, y_current - 1);
                            Console.WriteLine("Up " + utilityValues[3]);
                           // this.attack();
                            
                        }

                    }
                    Console.WriteLine(gamemap.getCell(x_current, y_current - 1));
                }


                int bestMove = -1;
                int min = 40;
                //  Boolean state = false;
                for (int i = 0; i < utilityValues.Length; i++)
                {
                    if (utilityValues[i] != -1 && min >= utilityValues[i])
                    {
                        min = utilityValues[i];
                        bestMove = i;

                    }
                }


                switch (bestMove)
                {

                    case 0: com.sendMessage_ToServer("RIGHT#");
                        Console.WriteLine("CHOOSED MOVE: RIGHT");
                        break;
                    case 1: com.sendMessage_ToServer("DOWN#");
                        Console.WriteLine("CHOOSED MOVE: DOWN");
                        break;
                    case 2: com.sendMessage_ToServer("LEFT#");
                        Console.WriteLine("CHOOSED MOVE: LEFT");
                        break;
                    case 3: com.sendMessage_ToServer("UP#");
                        Console.WriteLine("CHOOSED MOVE: UP");
                        break;
                    default: com.sendMessage_ToServer("SHOOT#");
                        Console.WriteLine("CHOOSED MOVE: SHOOT");
                        break;
                }
               // this.attack();
            
            }
        
        
        }
        
        
        private bool X_direct(int y_home,int y_target,int x) {

            bool state = true;
            int y_max = Math.Max(y_home, y_target);
            int y_min = Math.Min(y_home, y_target);

            for (int i = y_min + 1; i < y_max; i++) {
                if (gamemap.getCell(x, i).Split('_')[0].Equals("B") || gamemap.getCell(x, i).Split('_')[0].Equals("S"))
                {
                    return false;
                }

            }

            return state;
        
        }

        private bool Y_diect(int x_home, int x_target, int y) {

            bool state = true;
            int x_max = Math.Max(x_home, x_target);
            int x_min = Math.Min(x_home, x_target);

            for (int i = x_min + 1; i<x_max; i++) {
                if (gamemap.getCell(i, y).Split('_')[0].Equals("B") || gamemap.getCell(i, y).Split('_')[0].Equals("S"))
                {
                    return false;
                }
            }

            return state;

        }

      


        private int utilityFunction(int x_target, int y_target, int x_cuurent, int y_current) {

            int answer = 0; // 
            answer = Math.Abs(x_cuurent - x_target) + Math.Abs(y_current - y_target);
            return answer;
        } 


    }
          
       
}
