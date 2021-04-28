using System;
using System.Collections.Generic;

class HotelWiringSolution
{
    public static void HotelWiring()
    {
        int T = Convert.ToInt32(Console.ReadLine());

        for (int tc = 0; tc < T; tc++)
        {
            string[] input = Console.ReadLine().Split();
            int M = Convert.ToInt32(input[0]); // Num of floors.
            int N = Convert.ToInt32(input[1]); // Num of rooms per floor.
            int K = Convert.ToInt32(input[2]); // Num of master switches turned off.

            long maxNumOfRooms = 0;
            List<int> roomsWiredCorrectly = new List<int>();

            for (int floor = 0; floor < M; floor++) // Save num of wired correctly rooms per floor and sort list.
            {
                roomsWiredCorrectly.Add(Convert.ToInt32(Console.ReadLine()));
            }
            roomsWiredCorrectly.Sort();

            for (int k = 0; k < K; k++) // The K floors with min num of powered room will be switches off.
            {
                maxNumOfRooms += (N - roomsWiredCorrectly[k]); // (all rooms - powered rooms) will be powered.
            }

            for (int k = K; k < M; k++) // The rest M-k floors will be switches on.
            {
                maxNumOfRooms += roomsWiredCorrectly[k];
            }

            Console.WriteLine(maxNumOfRooms);
        }
    }

}
