Feature: LoginController	

Scenario: Login Success
	Given 帳號為 "ming"
	And 密碼為 "1234"	
	When 觸發登入HttpPost
	Then 回覆的頁面Controller應該為 "Welcome"
	And 回覆的頁面Action應該為 "Index"

Scenario: Login Fail
	Given 帳號為 "ming"
	And 密碼為 ""	
	When 觸發登入HttpPost Model驗證失敗
	Then ModelState應該沒通過