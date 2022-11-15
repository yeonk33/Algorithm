#include<iostream>
#include<string>

using namespace std;

int main(int argc, char** argv)
{
	int test_case;
	int T, zeroNum, inputLen;	// zeroNum: 유효숫자 뺀 자리수, inputLen: 입력받은 숫자 자리수
	string input = "";			// 입력을 string으로 받음
	cin >> T;

	for (test_case = 1; test_case <= T; ++test_case)
	{		
		cin >> input;
		inputLen = input.size();
		zeroNum = inputLen - 1;
		if (input[2] >= '5') {		// 반올림
			if (input[1] != '9') {	// 9가 아니면 1증가
				input[1] += 1;
			}
			else {						// 9이면	
				input[1] = '0';			// 0넣고
				if (input[0] == '9') {	// 그 윗자리가 9이면
					input[0] = '1';		// 1로 바꾸고
					zeroNum += 1;		// 자리수 늘림
				}
				else {					// 윗자리가 9가 아니면
					input[0] += 1;		// 그냥 1 증가
				}
			}
		}
		
		// 결과 출력
		cout << "#" << test_case << " " << input[0] << "." << input[1] << "*10^" << zeroNum << endl;
	}
	return 0;
}