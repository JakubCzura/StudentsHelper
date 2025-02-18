using Advice.Domain.Entities;

namespace Advice.Domain.SeedData;

public static class QuickTipSeed
{
    public static List<QuickTip> QuickTips { get; } =
    [
        new() { Title = "Learn slow", Description = "Are you trying to learn fast? It's a bad way, because you won't remember all necessary things. Try to learn slow, but focus on understanding how things work and how to resolve problems." },
        new() { Title = "Stay organized", Description = "Keep track of assignments, deadlines, and exams with a planner or digital calendar to stay on top of your studies." },
        new() { Title = "Take breaks", Description = "Studying too long without rest can reduce focus. Use the Pomodoro technique—25 minutes of study, 5-minute break." },
        new() { Title = "Use active recall", Description = "Test yourself often instead of just rereading notes. Active recall helps improve memory retention." },
        new() { Title = "Teach others", Description = "Explaining concepts to someone else forces you to understand the topic better, reinforcing your knowledge." },
        new() { Title = "Stay hydrated", Description = "Drink enough water throughout the day. Dehydration can cause fatigue and reduce concentration." },
        new() { Title = "Get enough sleep", Description = "Lack of sleep affects memory, focus, and problem-solving skills. Aim for 7-9 hours of quality rest." },
        new() { Title = "Avoid cramming", Description = "Studying last minute may help short-term, but long-term retention suffers. Space out your learning over time." },
        new() { Title = "Make study groups", Description = "Working with others can help clarify doubts, share insights, and keep you motivated." },
        new() { Title = "Use mind maps", Description = "Visualizing information helps with understanding complex topics and remembering key concepts." },
        new() { Title = "Find your peak time", Description = "Study when you're most alert. Some people learn best in the morning, others at night." },
        new() { Title = "Limit distractions", Description = "Turn off notifications, use focus apps, and create a quiet study environment for better concentration." },
        new() { Title = "Stay curious", Description = "Ask questions, explore beyond textbooks, and find ways to make learning interesting." },
        new() { Title = "Use different resources", Description = "Don't rely only on one textbook. Watch videos, listen to podcasts, and read articles to deepen understanding." },
        new() { Title = "Take good notes", Description = "Summarize key points in your own words and use bullet points, diagrams, and colors to make notes effective." },
        new() { Title = "Prioritize tasks", Description = "Use the Eisenhower Matrix: Urgent/Important tasks first, then Important but not Urgent." },
        new() { Title = "Exercise regularly", Description = "Physical activity boosts brain function and helps relieve stress, improving learning efficiency." },
        new() { Title = "Review daily", Description = "Go over your notes briefly each day to reinforce learning and prevent forgetting." },
        new() { Title = "Ask for help", Description = "Don't hesitate to seek guidance from teachers, tutors, or classmates if you're struggling." },
        new() { Title = "Use flashcards", Description = "Flashcards with spaced repetition improve recall of key facts and concepts." },
        new() { Title = "Avoid multitasking", Description = "Focus on one task at a time. Multitasking reduces efficiency and leads to mistakes." },
        new() { Title = "Stay positive", Description = "A good mindset can improve learning. Believe in yourself and stay motivated." },
        new() { Title = "Eat brain foods", Description = "Include nuts, berries, and omega-3-rich foods in your diet for better cognitive function." },
        new() { Title = "Learn by doing", Description = "Practical application of knowledge helps with understanding and retention." },
        new() { Title = "Use online tools", Description = "Apps like Anki, Quizlet, and Notion can help organize and optimize learning." },
        new() { Title = "Read actively", Description = "Highlight key points, take notes, and summarize as you read to improve comprehension." },
        new() { Title = "Set clear goals", Description = "Define short- and long-term academic goals to stay focused and motivated." },
        new() { Title = "Reduce stress", Description = "Practice meditation, deep breathing, or hobbies to manage stress effectively." },
        new() { Title = "Celebrate progress", Description = "Acknowledge small achievements to stay motivated and track improvement." }
    ];
}