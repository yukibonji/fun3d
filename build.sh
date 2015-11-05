CUR_DIR=$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )
ROOT_DIR=${CUR_DIR}
function prepare {
  [ ! -e ${ROOT_DIR}/.paket/paket.exe ] && mono ${ROOT_DIR}/.paket/paket.bootstrapper.exe
  [ ! -e ${ROOT_DIR}/packages/FAKE/tools/FAKE.exe ] && mono ${ROOT_DIR}/.paket/paket.exe restore
}

function build {
  mono ${ROOT_DIR}/packages/FAKE/tools/FAKE.exe ${ROOT_DIR}/build.fsx "$@"
}

prepare
[ "$0" = "$BASH_SOURCE" ] && build "$@"
