DIR=$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )
[ ! -e ${DIR}/.paket/paket.exe ] && mono ${DIR}/.paket/paket.bootstrapper.exe
[ ! -e ${DIR}/packages/FAKE/tools/FAKE.exe ] && mono ${DIR}/.paket/paket.exe restore

mono ${DIR}/packages/FAKE/tools/FAKE.exe build.fsx "$@"

