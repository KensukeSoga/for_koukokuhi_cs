package jp.co.isid.ham.base;

import javax.servlet.ServletContextEvent;
import javax.servlet.ServletContextListener;

import org.apache.log4j.LogManager;
import org.apache.log4j.xml.DOMConfigurator;

/**
 * <p>
 * アプリの初期化処理を行うServletContextListenerです
 * </p>
 * <p>
 * <b>修正履歴</b><br />
 * ・新規作成(2009/2/16 WT I.Kondo)<br />
 * </p>
 *
 * @author WT I.Kondo
 */
public class ApplicationInitializer implements ServletContextListener {

	/**
	 * Webアプリの起動時に呼ばれるメソッドです
	 * @param event ServletContextEvent
	 * @see javax.servlet.ServletContextListener#contextInitialized(javax.servlet.ServletContextEvent)
	 */
	public void contextInitialized(ServletContextEvent event) {
		loadLog4j();
	}

	/**
	 * Webアプリのシャットダウン時に呼ばれるメソッドです
	 * @param event ServletContextEvent
	 * @see javax.servlet.ServletContextListener#contextDestroyed(javax.servlet.ServletContextEvent)
	 */
	public void contextDestroyed(ServletContextEvent event) {
		destroyLog4j();
	}

	/**
	 * Log4j 設定ファイルを読み込みます
	 */
	private void loadLog4j() {
		try {
			DOMConfigurator.configure(HAMParameter.getInstance().getLog4jXMLPath());
		} catch (Throwable t) {
			System.out.println("○●○Log4Jのロード処理に失敗しました....");
			t.printStackTrace();
		}
	}

	/**
	 * Log4jをクローズします
	 */
	private void destroyLog4j() {
		try {
			LogManager.shutdown();
		} catch (Throwable t) {
			System.out.println("○●○Log4Jの開放に失敗しました");
		}
	}
}
