from dataclasses import dataclass, field

@dataclass
class Directory:
    name: str
    sub_directories: dict[str, "Directory"] = field(default_factory=dict)
    files: dict[str, "File"] = field(default_factory=dict)
    parent_directory: str = ''

    def total_size(self) -> int:
        files_sizes = sum(file.size for file in self.files.values())
        directory_sizes = sum(
            directory.total_size() for directory in self.sub_directories.values()
        )
        
        return files_sizes + directory_sizes

@dataclass
class File:
    name: str
    size: int
    parent_directory: str = ''