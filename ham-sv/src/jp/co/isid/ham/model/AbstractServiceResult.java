package jp.co.isid.ham.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.service.base.ErrorInfo;


/**
 * <P>
 * Web�T�[�r�X�̏������ʂ�ێ����钊�ۃN���X�ł�
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2010/12/13 ISID-IT K.Nukita)<BR>
 * </P>
 * @author ISID-IT K.Nukita
 */
@XmlRootElement(namespace = "http://model.ham.isid.co.jp/")
@XmlType(namespace = "http://model.ham.isid.co.jp/")
public abstract class AbstractServiceResult {

    /** �G���[��� */
    private ErrorInfo _errorInfo = new ErrorInfo();

    /**
     * �G���[����Ԃ��܂�
     * @return �G���[���
     */
    public ErrorInfo getErrorInfo() {
        return _errorInfo;
    }

    /**
     * �G���[����ݒ肵�܂�
     * @param errorInfo �G���[���
     */
    public void setErrorInfo(ErrorInfo errorInfo) {
        _errorInfo = errorInfo;
    }

    /**
    * �G���[���ۂ����擾���܂�
    * @return �G���[���ۂ�
    */
    public boolean isError() {

        if (_errorInfo == null) {
            return false;
        }
        return _errorInfo.isError();
    }

    /**
    * HAMException������ErrorInfo��ݒ肵�܂�
    * @param e HAMException
    */
    public void toErrorInfo(HAMException e) {
        ErrorInfo info = new ErrorInfo();
        info.setError(true);
        info.setErrorCode(e.getErrorID());
        info.setNote(e.getNoteList());
        this.setErrorInfo(info);
    }
}
