# This mini program is written by Nikola Tesla
# If you want to thank you the author, you can send a small gift to the wallet address
# BSC/Polygon/Ethereum: 0xcb7d6C5C1E1090343c5f004F088f5EE4BA548436
# Author: @NikolaTeslaOficial

#Trước khi chạy cài hai cái module này: tqdm và web3
#python WalletGenerate.py -i 100000 -o ad -s 30011991
#python WalletGenerate.py -i <so vi quét> -o <tên file cần xuất> -s <cụm từ ví m cần tìm>
import sys, getopt
from web3 import Web3
from tqdm import tqdm

# Get key from infura.io
KEY = "2c7d347514a44365aed6826b14faac88"
ethereumWallet = Web3( Web3.HTTPProvider( f'https://mainnet.infura.io/v3/{KEY}' ))

def search(searchText, inText):
    if searchText != '' and searchText in inText:
        return True
    return False

def writeWallet(file, data):
    file.write( "ACCOUNT %i: \n" % data.i )
    file.write( "Public Key: %s\n" % data.address )
    file.write( "Private Key: %s\n" % data.privateKey.hex() )
    file.write( "===============================================\n\n" )

def wallet( howManyWallet, outputfile, searchText = ''):

    # Checking input 
    if howManyWallet =='' and outputfile == '':
        howManyWallet = int( input( " [-] Please type number wallets to create: " ) or "50" )
        outputfile = str( input( " [-] Please type output filename ( default: wallet.txt )? " ) or "wallet.txt" )

    elif howManyWallet == '':
        howManyWallet = int( input( " [-] Please type number wallets to create: " ) or "50" )

    elif outputfile == '':
        outputfile = str( input( " [-] Please type output filename ( default: wallet.txt )? " ) or "wallet.txt" )

    # Open filename
    walletFileName = open( outputfile, "w" )

    # Loop creating wallet

    for i in tqdm( range( howManyWallet ) ):
            i = i+1
            account = ethereumWallet.eth.account.create()
            account.i = i
            if search(searchText, account.address) == True:
                # Search Wallet Mode Enable
                tqdm.write(" Found wallet with address %s" % account.address)
                writeWallet(walletFileName, account)

            elif searchText == '':
                # Normal Wallet Mode Enable
                tqdm.write(" Saving wallet: %s" % account.address)
                writeWallet(walletFileName, account)
    
    walletFileName.close()
    print( f" [+] Complete saved at '{outputfile}'!" )

def main( argv ):

    howManyWallet = ''
    outputFile = ''
    searchText = ''
    errors = f'OPTIONS\n\
            Run Command: ./{sys.argv[0]} -i <numberwallet> -o <outputfile> -s <search>\n\
            Options:\n\
            [-i]: Number wallets to create (number format)\n\
            [-o]: Filename to output\n\
            [-s]: Search Text\
            '
    helpers = errors
    
    try:
        opts, args = getopt.getopt( argv,"hi:o:s:",["numberwallet=","outputfile=", "search="] )

    except getopt.GetoptError:
        print( errors )
        sys.exit()

    for opt, arg in opts:

        if opt == '-h':
            print( helpers )
            sys.exit()

        elif opt in ( "-i", "--numberwallet" ):
            howManyWallet = arg

        elif opt in ( "-o", "--outputfile" ):
            outputFile = arg

        elif opt in ( "-s", "--search"):
            searchText = arg

        elif opt not in( "-i", "-o", "-s", "--numberwallet", "--outputfile", "--search"):
            print( errors )

    try:
        howManyWallet = howManyWallet !='' and int( howManyWallet ) or ''
    except ValueError as er:
        print(errors)
        sys.exit()

    wallet( howManyWallet, outputFile, searchText)

if __name__ == '__main__':
    main( sys.argv[1:] )
    