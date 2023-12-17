using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;



namespace WellnessStoreApi.Controllers
{
    [ApiController]
    [Route("api/wellness")]
    public class WellnessController : ControllerBase
    {
        private readonly List<Question> questions = new List<Question>
    {
    new Question("emotional well-being", "What was the best thing that happened to you today?"),
    new Question("emotional well-being", "What is something that made you laugh today?"),
    new Question("career", "What steps did you take today toward a goal you’re working on?"),
    new Question("relationships", "Who made your day better today? How can you pay that feeling forward?"),
    new Question("emotional well-being", "What made today unique?"),
    new Question("personal growth", "What is one thing you want to remember from today?"),
    new Question("emotional well-being", "When did you feel most authentically yourself today?"),
    new Question("emotional well-being", "How can you make tomorrow (even) better than today?"),
    new Question("mindfulness", "What activities bring you a sense of calm and peace?"),
    new Question("personal growth", "Did you practice self-care today? If so, what did you do?"),
    new Question("emotional well-being", "What are you grateful for right now?"),
    new Question("personal growth", "How did you challenge yourself today?"),
    new Question("emotional well-being", "What positive affirmations resonate with you today?"),
    new Question("community", "What is a small act of kindness you witnessed or performed?"),
    new Question("emotional well-being", "How do you handle stress, and what strategies did you use today?"),
    new Question("career", "What is a goal you have for the upcoming week?"),
    new Question("physical health", "Did you spend time in nature today? How did it make you feel?"),
    new Question("personal growth", "What is a skill or talent you are proud of?"),
    new Question("career", "How do you prioritize and manage your time effectively?"),
    new Question("mindfulness", "What is a book, movie, or song that inspired you recently?"),
    new Question("relationships", "Did you express your feelings and needs to someone today?"),
    new Question("work-life balance", "How do you maintain a healthy work-life balance?"),
    new Question("physical health", "What is a healthy habit you would like to develop?"),
    new Question("emotional well-being", "What brings you a sense of fulfillment in your life?"),
    new Question("personal growth", "Did you learn something new today? What was it?"),
    new Question("relationships", "How do you nurture and cultivate your relationships?"),
    new Question("emotional well-being", "What are your favorite ways to relax and unwind?"),
    new Question("emotional well-being", "Did you set any boundaries today? How did it feel?"),
    new Question("overcoming challenges", "How do you handle setbacks and failures?"),
    new Question("personal growth", "What positive changes have you noticed in yourself recently?"),
    new Question("emotional well-being", "What is a hobby or activity that brings you joy?"),
    new Question("mindfulness", "Did you practice mindfulness or meditation today?"),
    new Question("relationships", "Who is a positive influence in your life?"),
    new Question("emotional well-being", "How do you show kindness to yourself and others?"),
    new Question("career", "What is a goal or dream that you're working towards?"),
    new Question("relationships", "What is a memorable compliment you received recently?"),
    new Question("personal growth", "How do you celebrate your achievements, big or small?"),
    new Question("mindfulness", "What is a mantra or phrase that motivates you?"),
    new Question("tranquil spaces", "What is a place that brings you peace and tranquility?"),
    new Question("overcoming challenges", "What is a challenge you overcame today?"),
    new Question("emotional well-being", "How do you handle negative thoughts and self-talk?"),
    new Question("personal growth", "What is a habit you want to break or replace?"),
    new Question("community", "How do you foster a sense of community in your life?"),
    new Question("mindfulness", "What is a source of inspiration or motivation for you?"),
    new Question("sleep", "How do you ensure you get enough restful sleep?"),
    new Question("physical health", "What are your favorite ways to stay physically active?"),
    new Question("personal growth", "What is a goal you have for your personal development?"),
    new Question("creativity", "How do you express creativity in your daily life?"),
    new Question("emotional well-being", "What is something you love about yourself?"),
    new Question("emotional well-being", "How do you cope with challenging emotions?"),
    new Question("career", "What skills are you currently working on to advance your career?"),
    new Question("career", "How do you stay motivated during a busy workday?"),
    new Question("career", "What is a professional accomplishment you're proud of?"),
    new Question("relationships", "How do you show appreciation to the people you care about?"),
    new Question("relationships", "What qualities do you value in your close relationships?"),
    new Question("relationships", "How do you navigate conflicts in your relationships?"),
    new Question("personal growth", "What new habit are you trying to develop?"),
    new Question("personal growth", "In what ways have you stepped out of your comfort zone recently?"),
    new Question("personal growth", "What is a life lesson you've learned recently?"),
    new Question("mindfulness", "How do you stay present and mindful in your daily activities?"),
    new Question("mindfulness", "What mindful practices bring you a sense of calm?"),
    new Question("mindfulness", "How do you practice gratitude in your daily life?"),
    new Question("overcoming challenges", "What is a recent obstacle you've successfully overcome?"),
    new Question("overcoming challenges", "How do you stay resilient in the face of adversity?"),
    new Question("overcoming challenges", "What motivates you to overcome challenges?"),
    new Question("work-life balance", "What activities help you unwind after a busy day?"),
    new Question("work-life balance", "How do you set boundaries between work and personal life?"),
    new Question("work-life balance", "What brings balance to your daily routine?"),
    new Question("sleep", "What bedtime routine helps you relax and prepare for sleep?"),
    new Question("sleep", "How do you create a comfortable sleep environment?"),
    new Question("sleep", "What strategies do you use to improve the quality of your sleep?"),
    new Question("creativity", "What inspires your creative ideas or projects?"),
    new Question("creativity", "How do you overcome creative blocks or challenges?"),
    new Question("creativity", "In what ways do you express your creativity in daily life?"),
    new Question("tranquil spaces", "What natural environments bring you a sense of tranquility?"),
    new Question("tranquil spaces", "How do you create a peaceful space in your home?"),
    new Question("tranquil spaces", "What activities help you connect with a tranquil state of mind?"),
    new Question("sleep", "What bedtime routine helps you relax and prepare for sleep?"),
    new Question("sleep", "How do you create a comfortable sleep environment?"),
    new Question("sleep", "What strategies do you use to improve the quality of your sleep?"),
    new Question("creativity", "In what ways do you express your creativity in daily life?"),
    new Question("tranquil spaces", "What natural environments bring you a sense of tranquility?"),
    new Question("tranquil spaces", "How do you create a peaceful space in your home?"),
    new Question("tranquil spaces", "What activities help you connect with a tranquil state of mind?")
};

        [HttpGet]
        public IActionResult GetQuestions()
        {
            return Ok(questions);
        }
    }

    record Question(
        string category,
        string questions
    );
}
