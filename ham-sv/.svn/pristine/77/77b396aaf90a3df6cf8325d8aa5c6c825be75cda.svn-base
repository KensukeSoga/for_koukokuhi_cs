package jp.co.isid.ham.util;

import jp.co.isid.ham.model.base.HAMException;

import org.apache.log4j.Logger;

public class HAMLogUtility {

	/**
	 * インスタンス
	 */
	private static HAMLogUtility _Instance = null;

	/**
	 * Logger
	 */
	private Logger _logger;

	/**
	 * コンストラクタ
	 */
	private HAMLogUtility() {
		_logger = Logger.getLogger(HAMLogUtility.class.getName());
	}

	/**
	 * デフォルト出力
	 * @param message
	 */
	public static void outLog(String message) {
		info(message);
	}

	/**
	 * デフォルト出力
	 * @param message
	 */
	public static void outLog(HAMException e) {
		info(e);
	}

	/**
	 * DEBUG出力
	 * @param message
	 */
	public static void debug(String message) {
		if (_Instance == null) {
			_Instance = new HAMLogUtility();
		}
		_Instance._logger.info(message);
	}

	/**
	 * DEBUG出力
	 * @param e
	 */
	public static void debug(HAMException e) {
		debug(e.getMessage());
	}

	/**
	 * INFO出力
	 * @param message
	 */
	public static void info(String message) {
		if (_Instance == null) {
			_Instance = new HAMLogUtility();
		}
		_Instance._logger.info(message);
	}

	/**
	 * INFO出力
	 * @param e
	 */
	public static void info(HAMException e) {
		info(e.getMessage());
	}

	/**
	 * WARN出力
	 * @param message
	 */
	public static void warn(String message) {
		if (_Instance == null) {
			_Instance = new HAMLogUtility();
		}
		_Instance._logger.warn(message);
	}

	/**
	 * WARN出力
	 * @param e
	 */
	public static void warn(HAMException e) {
		warn(e.getMessage());
	}

	/**
	 * ERROR出力
	 * @param message
	 */
	public static void error(String message) {
		if (_Instance == null) {
			_Instance = new HAMLogUtility();
		}
		_Instance._logger.info(message);
	}

	/**
	 * ERROR出力
	 * @param e
	 */
	public static void error(HAMException e) {
		error(e.getMessage());
	}

	/**
	 * FATAL出力
	 * @param message
	 */
	public static void fatal(String message) {
		if (_Instance == null) {
			_Instance = new HAMLogUtility();
		}
		_Instance._logger.fatal(message);
	}

	/**
	 * FATAL出力
	 * @param e
	 */
	public static void fatal(HAMException e) {
		fatal(e.getMessage());
	}
}
