package jp.co.isid.ham.base;

import javax.servlet.ServletContextEvent;
import javax.servlet.ServletContextListener;

import org.apache.log4j.LogManager;
import org.apache.log4j.xml.DOMConfigurator;

/**
 * <p>
 * �A�v���̏������������s��ServletContextListener�ł�
 * </p>
 * <p>
 * <b>�C������</b><br />
 * �E�V�K�쐬(2009/2/16 WT I.Kondo)<br />
 * </p>
 *
 * @author WT I.Kondo
 */
public class ApplicationInitializer implements ServletContextListener {

	/**
	 * Web�A�v���̋N�����ɌĂ΂�郁�\�b�h�ł�
	 * @param event ServletContextEvent
	 * @see javax.servlet.ServletContextListener#contextInitialized(javax.servlet.ServletContextEvent)
	 */
	public void contextInitialized(ServletContextEvent event) {
		loadLog4j();
	}

	/**
	 * Web�A�v���̃V���b�g�_�E�����ɌĂ΂�郁�\�b�h�ł�
	 * @param event ServletContextEvent
	 * @see javax.servlet.ServletContextListener#contextDestroyed(javax.servlet.ServletContextEvent)
	 */
	public void contextDestroyed(ServletContextEvent event) {
		destroyLog4j();
	}

	/**
	 * Log4j �ݒ�t�@�C����ǂݍ��݂܂�
	 */
	private void loadLog4j() {
		try {
			DOMConfigurator.configure(HAMParameter.getInstance().getLog4jXMLPath());
		} catch (Throwable t) {
			System.out.println("������Log4J�̃��[�h�����Ɏ��s���܂���....");
			t.printStackTrace();
		}
	}

	/**
	 * Log4j���N���[�Y���܂�
	 */
	private void destroyLog4j() {
		try {
			LogManager.shutdown();
		} catch (Throwable t) {
			System.out.println("������Log4J�̊J���Ɏ��s���܂���");
		}
	}
}
