Feature: LoginController	

Scenario: Login Success
	Given 帳號為 "ming"
	And 密碼為 "1234"	
	When 觸發登入HttpPost
	Then 回覆的頁面Controller應該為 "Welcome"
	And 回覆的頁面Action應該為 "Index"

Scenario: Login Fail
	Given 帳號為 "ming"
	And 密碼為 "1222"	
	When 觸發登入HttpPost
	Then ModelState應該沒通過

Scenario: Login 沒打帳號和密碼
	Given 帳號為 ""
	And 密碼為 ""	
	When 觸發登入HttpPost
	Then ModelState驗證失敗