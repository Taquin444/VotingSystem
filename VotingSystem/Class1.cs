using System;
using System.Collections.Generic;

namespace SimpleVotingSystem
{
    class Candidate
    {
        public string Name { get; set; }

        public Candidate(string name)
        {
            Name = name;
        }
    }

    class VotingSystem
    {
        private List<Candidate> candidates = new List<Candidate>();
        private int[] votes = new int[10]; // Start with space for 10 candidates

        public void AddCandidate()
        {
            Console.Write("Enter candidate name: ");
            string name = Console.ReadLine();

            if (candidates.Exists(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Candidate already exists.\n");
                return;
            }

            if (candidates.Count == votes.Length)
            {
                // Resize array manually, similar to List<T> dynamic resizing
                int[] newVotes = new int[votes.Length * 2];
                for (int i = 0; i < votes.Length; i++)
                {
                    newVotes[i] = votes[i];
                }
                votes = newVotes;
                Console.WriteLine(" Votes array resized to accommodate more candidates.");
            }

            candidates.Add(new Candidate(name));
            Console.WriteLine("Candidate added successfully.\n");
        }

        public void CastVote()
        {
            if (candidates.Count == 0)
            {
                Console.WriteLine(" No candidates available.\n");
                return;
            }

            Console.WriteLine("\n--- Candidates ---");
            for (int i = 0; i < candidates.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {candidates[i].Name}");
            }

            Console.Write("Enter candidate number to vote: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                if (choice >= 1 && choice <= candidates.Count)
                {
                    votes[choice - 1]++;
                    Console.WriteLine(" Vote cast successfully.\n");
                }
                else
                {
                    Console.WriteLine(" Error choice.\n");
                }
            }
            else
            {
                Console.WriteLine(" Error input.\n");
            }
        }

        public void ShowResults()
        {
            if (candidates.Count == 0)
            {
                Console.WriteLine(" No candidates to display.\n");
                return;
            }

            Console.WriteLine("\n Voting Results:");
            for (int i = 0; i < candidates.Count; i++)
            {
                Console.WriteLine($"{candidates[i].Name}: {votes[i]} vote(s)");
            }
            Console.WriteLine();
        }

        public void ShowVoteMemory()
        {
            Console.WriteLine($" Vote array length: {votes.Length}");
            Console.WriteLine($" Candidates count: {candidates.Count}");
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            VotingSystem voting = new VotingSystem();
            bool running = true;

            while (running)
            {
                Console.WriteLine("=== Simple Voting System ===");
                Console.WriteLine("1. Add Candidate");
                Console.WriteLine("2. Cast Vote");
                Console.WriteLine("3. Show Results");
                Console.WriteLine("4. Show Memory Info");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice (1-5): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        voting.AddCandidate();
                        break;
                    case "2":
                        voting.CastVote();
                        break;
                    case "3":
                        voting.ShowResults();
                        break;
                    case "4":
                        voting.ShowVoteMemory();
                        break;
                    case "5":
                        Console.WriteLine("Exiting program.");
                        running = false;
                        break;
                    default:
                        Console.WriteLine(" Error choice. Try again.\n");
                        break;
                }
            }
        }
    }
}
