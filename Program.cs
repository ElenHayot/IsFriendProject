// See https://aka.ms/new-console-template for more information
internal class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, string> friendShips = new Dictionary<string, string>();
        List<string> me = new List<string>() { "Moi", "moi", "Me", "me", "Je", "je", "I" };
        string list = "NOK";
        string question = "";
        Console.WriteLine("Hello, World!");
        Console.WriteLine("Write your friendships <ami1> est ami avec <ami2>");
        while (String.IsNullOrEmpty(question))
            read();

        string isFriend = IsFriend(friendShips, question);
        Console.WriteLine(isFriend);

        // registers friendships
        void read()
        {
            string line = Console.ReadLine();
            if (line == "---")      // if list == "OK" then friendships list is complete
            {
                list = "OK";
                Console.WriteLine("Enter your question : Est-ce que <ami> est mon ami ?");
            }
            if (line != "---" && list != "OK")      // friendships list construction
            {
                var first = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).First();
                var second = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Last();
                if (me.Contains(first))
                    first = "ME";
                if (me.Contains(second))
                    second = "ME";
                friendShips.Add(first, second);
            }
            if (list == "OK" && line != "---")
                question = line;        // whichFriend's question

        }

        string IsFriend(Dictionary<string, string> friendShips, string question)
        {

            string theValueFriend = "";
            string theKeyFriend = "";
            string result = "False";

            var whichFriend = question.Split(' ').ElementAt(2);

            // does whichFriend have a friend ?
            var hasOneFriendIsKey = friendShips.Keys.Contains(whichFriend);
            var hasOneFriendIsValue = friendShips.Values.Contains(whichFriend);

            // if no friendship with whichFriend
            if (!hasOneFriendIsKey && !hasOneFriendIsValue)
                return "False";

            // finds whichFriend's friend
            if (hasOneFriendIsKey)
            {
                theValueFriend = friendShips[whichFriend];
            }
            if (hasOneFriendIsValue)
            {
                theKeyFriend = friendShips.FirstOrDefault(x => x.Equals(whichFriend)).Key;
            }

            // direct friendship with wichFriend ?
            if (theKeyFriend == "ME" || theValueFriend == "ME")
                result = "True";

            // my friend's friend is my friend
            if (!String.IsNullOrEmpty(theValueFriend) && friendShips.ContainsKey(theValueFriend) && friendShips[theValueFriend] == "ME")
                return "True";
            if (!String.IsNullOrEmpty(theKeyFriend) && friendShips.ContainsValue(theKeyFriend) && friendShips.FirstOrDefault(x => x.Equals(theKeyFriend)).Key == "ME")
                return "True";

            return result;

        }

    }


}