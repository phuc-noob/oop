using System;
using System.Collections.Generic;
using System.Text;

namespace englishTest
{
    class conversation:multiQuestion
    {
        public conversation(string[] Pharagraph, List<multiChoise> Questions, int level)
        {
            this.paragraph = Pharagraph;
            this.questions = Questions;
            this.level = level;
        }
    }
}
