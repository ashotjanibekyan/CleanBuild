#include <iostream>
#include <string>
#include <filesystem>

using namespace std;
namespace fs = std::filesystem;

void delete_bins_and_objs(string path);

int main(int argc, char* argv[])
{
    string root;
    if (argc > 1) {
        root = argv[1];
    }
    delete_bins_and_objs(root);

    cout << "Done" << endl;
    return 0;
}

void delete_bins_and_objs(string path)
{
    path = fs::absolute(path.empty() ? "." : path).string();
    if (!fs::exists(path))
    {
        return;
    }

    if (string binPath = (fs::path(path) / "bin").string(); fs::exists(binPath))
    {
        fs::remove_all(binPath);
        cout << ">> " << binPath << " deleted" << endl;
    }
    if (string objPath = (fs::path(path) / "obj").string(); fs::exists(objPath))
    {
        fs::remove_all(objPath);
        cout << ">> " << objPath << " deleted" << endl;
    }

    for (const auto& subDir : fs::directory_iterator(path))
    {
        if (subDir.is_directory())
        {
            delete_bins_and_objs(subDir.path().string());
        }
    }
}