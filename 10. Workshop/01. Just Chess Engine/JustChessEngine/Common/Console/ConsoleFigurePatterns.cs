namespace JustChessEngine.Common.Console
{
    using System;
    using System.Collections.Generic;
    using Figures;

    public class ConsoleFigurePatterns
    {
        public static IDictionary<Type, bool[,]> GetFiguresPatterns()
        {
            var patterns = new Dictionary<Type, bool[,]>()
            {
                {typeof(Pawn), new[,]
                    {
                        { false, false, false, false, false, false, false, false, false, },
                        { false, false, false, false, true, false, false, false, false, },
                        { false, false, false, true, true, true, false, false, false, },
                        { false, false, false, true, true, true, false, false, false, },
                        { false, false, false, false, true, false, false, false, false, },
                        { false, false, false, false, true, false, false, false, false, },
                        { false, false, false, true, true, true, false, false, false, },
                        { false, false, true, true, true, true, true, false, false, },
                        { false, false, false, false, false, false, false, false, false, },
                    }
                },

                {typeof(Rook), new[,]
                    {
                        { false, false, false, false, false, false, false, false, false, },
                        { false, false, true, false, true, false, true, false, false, },
                        { false, false, false, true, true, true, false, false, false, },
                        { false, false, false, true, true, true, false, false, false, },
                        { false, false, false, true, true, true, false, false, false, },
                        { false, false, false, true, true, true, false, false, false, },
                        { false, false, true, true, true, true, true, false, false, },
                        { false, false, true, true, true, true, true, false, false, },
                        { false, false, false, false, false, false, false, false, false, },
                    }
                },
                {typeof(Knight), new[,]
                    {
                        { false, false, false, false, false, false, false, false, false, },
                        { false, false, false, false, true, true, false, false, false, },
                        { false, false, false, true, true, true, true, false, false, },
                        { false, false, true, true, true, false, true, false, false, },
                        { false, false, false, true, false, true, true, false, false, },
                        { false, false, false, false, true, true, true, false, false, },
                        { false, false, false, true, true, true, false, false, false, },
                        { false, false, true, true, true, true, true, false, false, },
                        { false, false, false, false, false, false, false, false, false, },
                    }
                },
                {typeof(Bishop), new[,]
                    {
                        { false, false, false, false, false, false, false, false, false, },
                        { false, false, false, false, true, false, false, false, false, },
                        { false, false, false, true, true, true, false, false, false, },
                        { false, false, true, true, false, true, true, false, false, },
                        { false, false, true, false, false, false, true, false, false, },
                        { false, false, false, true, false, true, false, false, false, },
                        { false, false, false, false, true, false, false, false, false, },
                        { false, true, true, true, false, true, true, true, false, },
                        { false, false, false, false, false, false, false, false, false, },
                    }
                },
                {typeof(Queen), new[,]
                    {
                        { false, false, false, false, false, false, false, false, false, },
                        { false, false, false, false, true, false, false, false, false, },
                        { false, false, true, false, true, false, true, false, false, },
                        { false, false, false, true, false, true, false, false, false, },
                        { false, true, false, true, true, true, false, true, false, },
                        { false, false, true, false, true, false, true, false, false, },
                        { false, false, true, true, false, true, true, false, false, },
                        { false, false, true, true, true, true, true, false, false, },
                        { false, false, false, false, false, false, false, false, false, },
                    }
                },
                {typeof(King), new[,]
                    {
                        { false, false, false, false, false, false, false, false, false, },
                        { false, false, false, false, true, false, false, false, false, },
                        { false, false, false, true, true, true, false, false, false, },
                        { false, true, true, false, true, false, true, true, false, },
                        { false, true, true, true, false, true, true, true, false, },
                        { false, true, true, true, true, true, true, true, false, },
                        { false, false, true, true, true, true, true, false, false, },
                        { false, false, true, true, true, true, true, false, false, },
                        { false, false, false, false, false, false, false, false, false, },
                    }
                }
            };

            return patterns;
        }
    }
}