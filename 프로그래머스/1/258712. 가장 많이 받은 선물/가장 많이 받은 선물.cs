using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int solution(string[] friends, string[] gifts) {
        int answer = 0;
        int n = friends.Length;
        int[,] giftTable = new int[n,n]; // 선물 주고받은 기록
        Dictionary<string, int> nameIndexs = new Dictionary<string, int>(); // 이름을 인덱스로 접근하기 위해
        int[] presentValues = new int[n]; // 선물 지수
        int[] nextMonth = new int[n];
        
        for (int i = 0; i < n; i++) {
            nameIndexs.Add(friends[i], i);
        }
        
        // 입력 받아서 테이블에 저장하기
        for (int i = 0; i < gifts.Length; i++) {
            string[] inputs = gifts[i].Split(' ');
            string give = inputs[0]; // 준 사람
            string take = inputs[1]; // 받은 사람
            
            giftTable[nameIndexs[give], nameIndexs[take]]++;
            presentValues[nameIndexs[give]]++; // 선물 지수 계산
            presentValues[nameIndexs[take]]--; // 선물 지수 계산
        }        
        
        // 다음달 받을 선물 개수 계산하고 기록
        for (int i = 0; i < n; i++) {
            string nextGive;
            for (int j = i+1; j < n; j++) {
                int A = giftTable[i,j];
                int B = giftTable[j,i];
                
                // 주고 받은 선물 개수 비교
                if (A > B) {
                    nextMonth[i]++;
                } else if (A < B) {
                    nextMonth[j]++;
                    
                } else { // 같은 경우
                    int AP = presentValues[i];
                    int BP = presentValues[j];
                     // 선물 지수 비교
                    if (AP > BP) {
                        nextMonth[i]++;
                    } else if (AP < BP) {
                        nextMonth[j]++;
                    }
                }
            }
            
        }
        
        // 가장 큰 사람 찾기
        answer = nextMonth.Max();
        
        return answer;
    }
}