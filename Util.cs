using System;
using System.IO;

namespace PdfDemo
{
    static class Util
    {
        static string _samplesDir;
        /// <summary>
        /// Gets the default samples folder.
        /// </summary>
        public static string SamplesDir
        {
            get
            {
                if (_samplesDir == null)
                {
                    _samplesDir = System.IO.Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\PdfSamples");
                    if (!System.IO.Directory.Exists(_samplesDir))
                        _samplesDir = AppDomain.CurrentDomain.BaseDirectory + "PdfSamples";
                }

                return _samplesDir;
            }
        }

        static string _outputDir;
        /// <summary>
        /// Gets the default output folder.
        /// </summary>
        public static string OutputDir
        {
            get
            {
                if (_outputDir == null)
                {
                    _outputDir = System.IO.Path.GetDirectoryName(SamplesDir) + "\\Output";

                    if (!Directory.Exists(_outputDir))
                        Directory.CreateDirectory(_outputDir);
                }

                return _outputDir;
            }
        }

        static string _dataDir;
        /// <summary>
        /// Gets the default data folder.
        /// </summary>
        public static string DataDir
        {
            get
            {
                if (_dataDir == null)
                {
                    _dataDir = System.IO.Path.GetDirectoryName(_samplesDir) + "\\Data";
                }

                return _dataDir;
            }
        }
    }
}
