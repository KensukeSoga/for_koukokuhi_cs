package jp.co.isid.ham.base;

import java.util.Properties;

import jp.co.isid.nj.util.config.Parameter;
import jp.co.isid.nj.util.config.ParameterFactory;


/**
 * <p>
 * HAM �V�X�e���̃p�����[�^�N���X
 * </p>
 * <p>
 * <b>�C������</b><br />
 * �E�V�K�쐬(2006/09/22 WT H.Ikeda)<br />
 * �EHDX�Ή�(2016/04/12 HLC K.Oki)<BR>
 * </p>
 *
 * @author WT H.Ikeda
 */
public class HAMParameter extends Parameter {

    /** serialVersionUID */
    private static final long serialVersionUID = -8517552208554056131L;
    /** �V�X�e���R�[�h */
    public static final String SYSTEM_CODE = "HAM";


    /**
     * �f�t�H���g�R���X�g���N�^�ł�
     * �t���[�����[�N�ɂ��Ăяo����܂�
     */
    public HAMParameter() {
    }

    /**
     * �C���X�^���X��Ԃ��܂�
     *
     * @return �C���X�^���X
     */
    public static HAMParameter getInstance() {
        return (HAMParameter) ParameterFactory.getParameter(SYSTEM_CODE);
    }

    /**
     * �f�[�^�\�[�X�̎g�p�L����Ԃ��܂�
     * @return true�̏ꍇ�A�f�[�^�\�[�X���g�p����
     */
    public boolean isDataSourceUse() {
        String val = (String)getValue("SQLSDataSourceUse");
        return (val != null && "true".equals(val)) ? true : false;
    }

    /**
     * SQLServer�f�[�^�\�[�X����Ԃ��܂�
     * @return �f�[�^�\�[�X��
     */
    public String getDataSourceName() {
        return (String)getValue("SQLSDataSourceName");
    }

    /**
     * JDBCDriver����Ԃ��܂�
     *
     * @return JDBCDriver��
     */
    public String getDBDriver() {
        return (String) getValue("DBDriver");
    }

    /**
     * �f�[�^�x�[�X URL ��Ԃ��܂�
     *
     * @return �f�[�^�x�[�X URL
     */
    public String getDBUrl() {
        return (String) getValue("DBUrl");
    }

    /**
     * DB �ڑ��v���p�e�B��Ԃ��܂�
     *
     * @return Properties DB �ڑ��v���p�e�B
     */
    public Properties getDriverProperties() {
        return toProperties((String) getValue("DBKey"), (String) getValue("DBParameter"));
    }

    /**
     * �Ɩ���vJDBCDriver����Ԃ��܂�
     *
     * @return �Ɩ���vJDBCDriver��
     */
    public String getECDBDriver() {
        return (String) getValue("ECDBDriver");
    }

    /**
     * �Ɩ���v�f�[�^�x�[�XURL��Ԃ��܂�
     *
     * @return �Ɩ���v�f�[�^�x�[�XURL
     */
    public String getECDBUrl() {
        return (String) getValue("ECDBUrl");
    }

    /**
     * �Ɩ���vDB�ڑ��v���p�e�B��Ԃ��܂�
     *
     * @return �Ɩ���vDB�ڑ��v���p�e�B
     */
    public Properties getECDriverProperties() {
        return toProperties((String) getValue("ECDBKey"), (String) getValue("ECDBParameter"));
    }

    /**
     * �R���}��؂�̃L�[�ƒl��Properties�I�u�W�F�N�g�ɕϊ����ĕԂ��܂�
     *
     * @param strKeys String �L�[�̃R���}��؂蕶����
     * @param strValues String �l�̃R���}��؂蕶����
     * @return Properties �ϊ����Properties�I�u�W�F�N�g
     */
    private Properties toProperties(String strKeys, String strValues) {
        Properties props = null;
        String[] keys = getCommaString2Array(strKeys);
        String[] values = getCommaString2Array(strValues);
        // �p�����[�^�̃Z�b�g
        if (haveKeys(keys)) {
            props = new Properties();
            for (int i = 0; i < keys.length; i++) {
                props.setProperty(keys[i], values[i]);
            }
        }
        return props;
    }

    /**
     * �L�[��ێ����Ă��邩�𔻒肵�܂�
     *
     * @param keys String[] �L�[
     * @return true:�ێ����Ă��� false:�ێ����Ă��Ȃ�
     */
    private boolean haveKeys(String[] keys) {
        return (keys != null) && (keys.length != 0);
    }

    /**
     * CommandInvoker ����Ԃ��܂�
     * @return CommandInvoker ��
     */
    public String getCommandInvokerName() {
        return "forServer";
    }

    /**
     * log4j.xml �̃p�X��Ԃ��܂�
     * @return log4j.xml �̃p�X
     */
    public String getLog4jXMLPath() {
        return (String) getValue("Log4jXMLPath");
    }

    /**
     * SMTP�T�[�o�[�̃T�[�o�[��(or�A�h���X) ��Ԃ��܂�
     *
     * @return SMTP�T�[�o�[�̃T�[�o�[��(or�A�h���X)
     */
    public String getSmtpHost() {
        return (String) getValue("SmtpHost");
    }

    /**
     * SMTP�T�[�o�[�̃|�[�g�ԍ���Ԃ��܂�
     *
     * @return SMTP�T�[�o�[�̃|�[�g�ԍ�
     */
    public String getSmtpPort() {
        return (String) getValue("SmtpPort");
    }

    /* 2016/04/12 HDX�Ή� HLC K.Oki ADD Start */
    /**
     * �Ɩ���v�f�[�^�\�[�X�̎g�p�L����Ԃ��܂�
     * @return true�̏ꍇ�A�f�[�^�\�[�X���g�p����
     */
    public boolean isECDataSourceUse() {
        String val = (String)getValue("ECSQLSDataSourceUse");
        return (val != null && "true".equals(val)) ? true : false;
    }

    /**
     * �Ɩ���vSQLServer�f�[�^�\�[�X����Ԃ��܂�
     * @return �f�[�^�\�[�X��
     */
    public String getECDataSourceName() {
        return (String)getValue("ECSQLSDataSourceName");
    }
    /* 2016/04/12 HDX�Ή� HLC K.Oki ADD End */

}
