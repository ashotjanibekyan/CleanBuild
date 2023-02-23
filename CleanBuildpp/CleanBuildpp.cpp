#include <iostream>
#include <filesystem>

using namespace std;
namespace fs = std::filesystem;

void delete_bins_and_objs(const string *path)
{
    auto root = fs::absolute(fs::path(*path));
    if (!fs::exists(root) || !fs::is_directory(root))
    {
        return;
    }
    auto binPath = fs::path(root).append("bin");
    auto objPath = fs::path(root).append("obj");
    vector<fs::path> pathsToDelete;
    for (const auto& dirEntry : fs::recursive_directory_iterator(*path))
    {
        if (dirEntry.is_directory() && (dirEntry.path().filename() == "bin" || dirEntry.path().filename() == "obj"))
        {
            pathsToDelete.push_back(dirEntry.path());
        }
    }
    for (fs::path const &pathToDelete : pathsToDelete)
    {
        if (fs::exists(pathToDelete) && fs::is_directory(pathToDelete))
        {
            try
            {
                fs::remove_all(pathToDelete);
                cout << ">> " << pathToDelete << " deleted" << endl;
            }
            catch (exception &ex)
            {
                cout << ex.what() << endl;
            }
        }
    }
}


int main(int argc, char* argv[])
{
    string s1 = argv[1];
    delete_bins_and_objs(&s1);
    cout << "Done" << endl;
}