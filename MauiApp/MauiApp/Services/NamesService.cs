using SQLite;
using System.Collections;

namespace MauiBeyond.Services
{
    public class NamesService
    {
        private async Task CreateDBFileIfNeeded()
        {
            if (!File.Exists($"{FileSystem.AppDataDirectory}/names.sqlite3"))
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync("names.sqlite3");
                {
                    var reader = new BinaryReader(stream);

                    using (var destinationFileStream = new FileStream($"{FileSystem.AppDataDirectory}/names.sqlite3", FileMode.OpenOrCreate))
                    {
                        stream.CopyTo(destinationFileStream);
                    }
                }
            }
        }
        public async Task<IEnumerable<string>> GetNamesEnumerable()
        {
            await CreateDBFileIfNeeded();
            return new NameEnumerable();
        }

        public async Task<List<string>> GetAllNames()
        {
            await CreateDBFileIfNeeded();
            return new NameEnumerable().ToList<string>();
        }
    }

    // The use of the NameEnumerable and NameEnumerator are to
    // load data from the SQLite table in pages instead of all at 
    // once or passing back the Table's IEnumerator which would
    // keep the database connection open.
    internal class NameEnumerable : IEnumerable<string>
    {
        private NameEnumerator _enumerator;
        internal NameEnumerable()
        {
            _enumerator = new NameEnumerator();
        }

        public IEnumerator<string> GetEnumerator()
        {
            return _enumerator;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _enumerator;
        }
    }

    internal class NameEnumerator : IEnumerator<string>, IDisposable
    {
        private const int PAGE_SIZE = 100;
        private int _currentPosition = 0;
        private int _currentRecordInPage = 0;
        private List<string> _currentNamePage;

        internal NameEnumerator()
        {
            LoadNextPage();
        }

        private bool LoadNextPage()
        {
            _currentRecordInPage = -1;

            using (var cn = new SQLiteConnection($"{FileSystem.AppDataDirectory}/names.sqlite3"))
            {
                var result = cn.Table<Names>().Skip(_currentPosition).Take(PAGE_SIZE);
                _currentNamePage = new List<string>();

                foreach (var record in result)
                {
                    _currentRecordInPage = 0;
                    _currentPosition += 1;
                    _currentNamePage.Add(record.Name);
                }
            }

            return _currentRecordInPage > -1;
        }

        public object Current
        {
            get
            {
                if (_currentRecordInPage < 0 || _currentNamePage == null || _currentRecordInPage + 1 > _currentNamePage.Count)
                {
                    return null;
                }
                else
                {

                    var returnValue= _currentNamePage[_currentRecordInPage];
                    _currentRecordInPage += 1;
                    return returnValue;
                }
            }
        }

        string IEnumerator<string>.Current => Current as string;

        public bool MoveNext()
        {
            if (_currentRecordInPage + 1 >= _currentNamePage.Count)
            {
                return LoadNextPage();
            }
            else
            {
                return true;
            }
        }

        public void Reset()
        {
            _currentPosition = 0;
            LoadNextPage();
        }

        public void Dispose()
        {

        }
    }

    [SQLite.Table("names")]
    public class Names
    {
        [SQLite.Column("name")]
        public string Name { get; set; }
    }
}
