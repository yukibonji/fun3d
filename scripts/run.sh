source $( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )/build.sh

function execute {
  mono ${ROOT_DIR}/Binaries/fun3d.exe
}

build
execute
