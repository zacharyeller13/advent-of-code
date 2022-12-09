import os
from pprint import pprint

from fs_classes import Directory, File

# '/' is root directory
# '$' precedes commands we execute(d)
# 'cd' = change directory
# 'cd x' = looks for directory 'x' and moves into it
# 'cd ..' = moves out 1 directory
# 'cd /' = move to root directory
# 'ls' = list all directories and files in current
# '123 abc' = filesize 123 filename abc
# 'dir xyz' = directory named xyz

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
            # print(f"command: {' '.join(input_line[1:])}")

            if input_line[1] == 'cd':
                cwd, prev_dir = change_dir(cwd, input_line[-1])
                if cwd == '..':
                    pass
                    # cwd = filesystem.sub_directories.get(prev_dir).parent_directory

                # print(f"prev_dir: {prev_dir} | cwd: {cwd}")

        else:
            # print(f"file/dir: {input_line}")
            update_filesystem(filesystem, cwd, input_line)

    pprint(filesystem)

def change_dir(cwd: str, new_cwd: str) -> tuple[str, str]:

    return new_cwd, cwd

def update_filesystem(filesystem: Directory, cwd: str, input_line: list[str]) -> None:
    """
    Update the filesystem in place, adding a `Directory` or `File` where applicable
    """

    if input_line[0] == 'dir':
        new_dir_name = input_line[-1]

        if new_dir_name != '/' and cwd == '/' and not filesystem.sub_directories.get(new_dir_name):
            # use .get(new_dire_name) to check if the directory already exists
            # we don't want to overwrite a dir that already has files in it

            filesystem\
            .sub_directories[new_dir_name] = Directory(new_dir_name, parent_directory=cwd)

        elif new_dir_name != '/' and filesystem.sub_directories.get(cwd):

            filesystem\
            .sub_directories[cwd]\
            .sub_directories[new_dir_name] = Directory(new_dir_name, parent_directory=cwd)

    else:
        file_size = int(input_line[0])
        file_name = input_line[-1]

        if cwd != '/':
            for dir_name, dir in filesystem.sub_directories.items():

                if dir_name == cwd:
                    filesystem\
                    .sub_directories[cwd]\
                    .files[file_name] = File(file_name, file_size, parent_directory=cwd)
                    
                else:
                    for dir_name2, _ in dir.sub_directories.items():
                        if dir_name2 == cwd:
                            dir\
                            .sub_directories[cwd]\
                            .files[file_name] = File(file_name, file_size, parent_directory=cwd)

        else:
            filesystem.files[file_name] = File(file_name, file_size, parent_directory=cwd)

def create_filesystem() -> Directory:
    """
    Create a new `Directory` object and return it as the root directory
    """

    root_dir = Directory('/')

    return root_dir

def main() -> None:

    inputs = read_input(f"{os.path.dirname(__file__)}/test_inputs")
    # commands = get_commands(inputs)

    filesystem = create_filesystem()

    # print(file_system)
    # print(commands)
    build_filesystem(filesystem, inputs)

    # root_dir = Directory('/')
    # root_dir.sub_directories['a'] = Directory('a', parent_directory='/')
    # root_dir.files['abc'] = File('abc', 100, '/')
    # pprint(root_dir)
    # print(root_dir.total_size())


if __name__ == "__main__":
    main()