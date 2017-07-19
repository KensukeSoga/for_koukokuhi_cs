package jp.co.isid.ham.login.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;


@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class MprKengenCheckResult extends AbstractServiceResult {

    /**
     * �c�Ə��R�[�h
     */
    private String _egsCd = null;

    /**
     * ���Ό���
     */
    private String _relativeAuthority = null;

    /**
     * MPR�����`�F�b�N����
     */
    private boolean _checkResult = false;

    /**
     * �c�Ə��R�[�h���擾����
     *
     * @return _egsCd
     */
    public String getEgsCd() {
        return _egsCd;
    }

    /**
     * �c�Ə��R�[�h��ݒ肷��
     * @param egsCd _egsCd
     */
    public void setEgsCd(String egsCd) {
        _egsCd = egsCd;
    }

    /**
     * ���Ό������擾����
     *
     * @return ���Ό���
     */
    public String getRelativeAuthority() {
        return _relativeAuthority;
    }

    /**
     * ���Ό�����ݒ肷��
     * @param relativeAuthority ���Ό���
     */
    public void setRelativeAuthority(String relativeAuthority) {
        _relativeAuthority = relativeAuthority;
    }

    /**
     * MPR�����`�F�b�N���ʂ��擾����
     *
     * @return MPR�����`�F�b�N����
     */
    public boolean getCheckResult() {
        return _checkResult;
    }

    /**
     * MPR�����`�F�b�N���ʂ�ݒ肷��
     * @param checkResult MPR�����`�F�b�N����
     */
    public void setCheckResult(boolean checkResult) {
        _checkResult = checkResult;
    }
}
