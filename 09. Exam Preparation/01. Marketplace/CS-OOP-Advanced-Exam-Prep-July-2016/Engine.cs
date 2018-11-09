namespace CS_OOP_Advanced_Exam_Prep_July_2016
{
    using System;
    using Framework.Dispatchers;
    using Framework.Lifecycle.Component;
    using Framework.Lifecycle.Request;
    using IO.Readers;
    using IO.Writers;

    [Component]
    public class Engine : IEngine
    {
        private const string END_LINE = "ILIENCI";

        [Inject]
        private IWriter writer;

        [Inject]
        private IReader reader;

        [Inject]
        private IDispatcher dispatcher;

        public void Run()
        {
            var line = this.reader.ReadLine();

            while (line != END_LINE)
            {
                var tokens = line.Split();

                var requestMethod = (RequestMethod)Enum.Parse(typeof(RequestMethod), tokens[0]);
                var uri = tokens[1];
                var result = this.dispatcher.Dispatch(requestMethod, uri);

                this.writer.WriteLine(result);

                line = this.reader.ReadLine();
            }
        }
    }
}