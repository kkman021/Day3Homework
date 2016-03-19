Feature: Login
	#In order to avoid silly mistakes
	#As a math idiot
	#I want to be told the sum of two numbers

Scenario: 登入成功
	Given 我前往登入頁面
	And 帳號輸入 "ming"
	And 密碼輸入 "1234"
	When 當我按下登入
	Then 應該導回歡迎頁面
	And 畫面應該呈現 "welcome, ming"