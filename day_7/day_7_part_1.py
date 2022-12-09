import os
from pprint import pprint

from fs_classes import Directory, File

def read_input(file: str) -> list[str]:

    with open(f"{file}", 'r') as f:

        inputs = f.read()
        inputs = inputs.split('\n')
    
    return inputs

def build_filesystem(filesystem: Directory, inputs: list[str]) -> None:

    cwd = '/'
    for line in inputs:
        input_line = line.split()

        if input_line[0] == '$':

            if input_line[1] == 'cd':

                cwd, prev_dir = change_dir(cwd, input_line[-1])

                if cwd == '..':
                    pass

        else:
            update_filesystem(filesystem, cwd, input_line)

    # pprint(filesystem)

def change_dir(cwd: str, new_cwd: str) -> tuple[str, str]:

    return new_cwd, cwd

def update_filesystem(filesystem: Directory, cwd: str, input_line: list[str]) -> None:
    """
    Update the filesystem in place, adding a `Directory` or `File` where applicable
    """

    if input_line[0] == 'dir':
        new_dir_name = input_line[-1]

        if new_dir_name != '/' and cwd == '/' and not filesystem.sub_directories.get(new_dir_name):
            # use .get(new_dir_name) to check if the directory already exists
            # we don't want to overwrite a dir that already has files in it

            filesystem\
            .sub_directories[new_dir_name] = Directory(new_dir_name, parent_directory=cwd)

        else:
            dir = find_directory(filesystem, cwd)

            if dir:
                dir.sub_directories[new_dir_name] = Directory(new_dir_name, parent_directory=cwd)

    else:
        file_size = int(input_line[0])
        file_name = input_line[-1]

        if cwd != '/':
            dir = find_directory(filesystem, cwd)

            if dir:
                dir.files[file_name] = File(file_name, file_size, parent_directory=cwd)

        else:
            filesystem.files[file_name] = File(file_name, file_size, parent_directory=cwd)

def find_directory(directory: Directory, dir_to_find: str) -> Directory | None:
    """
    Recursively search sub_directories to find a specific `Directory`
    """

    if dir_to_find in directory.sub_directories:
        return directory.sub_directories.get(dir_to_find)

    for _, dir in directory.sub_directories.items():
        if isinstance(dir, Directory):
            dir = find_directory(dir, dir_to_find)
            if dir:
                return dir

    return None

def sum_dir_sizes(directory: Directory, dir_size: int) -> int:
    
    dir_sizes = 0
    for _, dir in directory.sub_directories.items():
        if dir.total_size() <= dir_size:
            dir_sizes += dir.total_size()
        else:
            dir_sizes += sum_dir_sizes(dir, dir_size)

    return dir_sizes

def create_filesystem() -> Directory:
    """
    Create a new `Directory` object and return it as the root directory
    """

    return Directory('/')

def main() -> None:

    inputs = read_input(f"{os.path.dirname(__file__)}/inputs")

    filesystem = create_filesystem()

    build_filesystem(filesystem, inputs)

    small_dirs = sum_dir_sizes(filesystem, 100000)

    print(small_dirs)

if __name__ == "__main__":
    main()