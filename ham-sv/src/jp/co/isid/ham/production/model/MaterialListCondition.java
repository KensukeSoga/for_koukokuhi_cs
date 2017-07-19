package jp.co.isid.ham.production.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <P>
 * �f�ވꗗ�����N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/30 �VHAM�`�[��)<BR>
 * �EJASRAC�Ή�(2015/12/9 HLC K.Soga)<BR>
 * �EHDX�Ή�(2016/11/11 HLC K.Soga)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class MaterialListCondition implements Serializable {

    private static final long serialVersionUID = 1L;

    /** �S����ID */
    private String _hamid = null;

    /** �S����ID */
    private String _hamNm = null;

    /** ���[�U��� */
    private String _usertype = null;

    /** �ǃR�[�h */
    private String _kksikognzuntcd = null;

    /** �t�F�C�Y */
    private String _phase = null;

    /** �@�\�R�[�h */
    private String _functionCd = null;

    /** ���ID */
    private String _formid = null;

    /** �Ώ۔N�� */
    private String _ymDate = null;

    /** �R�s�[���[�h */
    private boolean _copyMode = false;

    /** �Ԏ�R�[�h */
    private String _dCarCd = null;

    /** �쐬�敪 */
    private String _recKbn = null;

    /** �쐬�ԍ� */
    private String _recNo = null;

    /** 2015/12/9 JASRAC�Ή� HLC K.Soga ADD Start */
    /** 10��CM�R�[�h */
    private String _cmCd = null;

    /** ��10��CM�R�[�h */
    private String _tempCmCd = null;

    /** �^�C�g�� */
    private String _title = null;
    /** 2015/12/9 JASRAC�Ή� HLC K.Soga ADD End */

    /** 2016/04/12 HDX�Ή� HLC K.Soga ADD Start */
    /** �f�ޓo�^�f�[�^�S���\���t���O */
    private boolean _dispAllList = false;

    /** �f�ޓo�^�f�[�^�S���\���p�A���ݔN���� */
    private String _dispAllListYmDate = null;
    /** 2016/04/12 HDX�Ή� HLC K.Soga ADD End */

    /**
     * �S����ID���擾����
     *
     * @return �S����ID
     */
    public String getHamid() {
        return _hamid;
    }

    /**
     * �S����ID��ݒ肷��
     *
     * @param hamid �S����ID
     */
    public void setHamid(String hamid) {
        this._hamid = hamid;
    }

    /**
     * �S���Җ����擾����
     *
     * @return �S���Җ�
     */
    public String getHamNm() {
        return _hamNm;
    }

    /**
     * �S���Җ���ݒ肷��
     *
     * @param hamid �S���Җ�
     */
    public void setHamNm(String val) {
        this._hamNm = val;
    }

    /**
     * ���[�U��ʂ��擾����
     *
     * @return ���[�U���
     */
    public String getUsertype() {
        return _usertype;
    }

    /**
     * ���[�U��ʂ�ݒ肷��
     *
     * @param usertype ���[�U���
     */
    public void setUsertype(String usertype) {
        this._usertype = usertype;
    }

    /**
     * �ǃR�[�h���擾����
     *
     * @return �ǃR�[�h
     */
    public String getKksikognzuntcd() {
        return _kksikognzuntcd;
    }

    /**
     * �ǃR�[�h��ݒ肷��
     *
     * @param kksikognzuntcd �ǃR�[�h
     */
    public void setKksikognzuntcd(String kksikognzuntcd) {
        this._kksikognzuntcd = kksikognzuntcd;
    }

    /**
     * �@�\�R�[�h��ݒ肵�܂�
     * @param val
     */
    public void setFunctionCd(String val) {
        _functionCd = val;
    }

    /**
     * �@�\�R�[�h���擾���܂�
     * @return
     */
    public String getFunctionCd() {
        return _functionCd;
    }

    /**
     * ���ID���擾����
     *
     * @return ���ID
     */
    public String getFormid() {
        return _formid;
    }

    /**
     * ���ID��ݒ肷��
     *
     * @param formid ���ID
     */
    public void setFormid(String formid) {
        this._formid = formid;
    }

    /**
     * �t�F�C�Y��ݒ肵�܂�
     * @param val �t�F�C�Y
     */
    public void setPhase(String val) {
        _phase = val;
    }

    /**
     * �t�F�C�Y���擾���܂�
     * @return �t�F�C�Y
     */
    public String getPhase() {
        return _phase;
    }

    /**
     * �Ώ۔N����ݒ肵�܂�
     * @param val �Ώ۔N��
     */
    public void setYmDate(String val) {
        _ymDate = val;
    }

    /**
     * �Ώ۔N�����擾���܂�
     * @return �Ώ۔N��
     */
    public String getYmDate() {
        return _ymDate;
    }

    /**
     * �R�s�[���[�h��ݒ肵�܂�
     * @param val
     */
    public void setCopyMode(boolean val) {
        _copyMode = val;
    }

    /**
     * �R�s�[���[�h���擾���܂�
     * @return
     */
    public boolean getCopyMode() {
        return _copyMode;
    }

    /**
     * �Ԏ�R�[�h��ݒ肵�܂�
     * @param val
     */
    public void setDCarCd(String val) {
        _dCarCd = val;
    }

    /**
     * �Ԏ�R�[�h���擾���܂�
     * @return
     */
    public String getDCarCd() {
        return _dCarCd;
    }

    /**
     * �쐬�敪��ݒ肵�܂�
     * @return
     */
    public void setRecKbn(String val) {
        _recKbn = val;
    }

    /**
     * �쐬�敪���擾���܂�
     * @return
     */
    public String getRecKbn() {
        return _recKbn;
    }

    /**
     * �쐬�ԍ���ݒ肵�܂�
     * @param val
     */
    public void setRecNo(String val) {
        _recNo = val;
    }

    /**
     * �쐬�ԍ����擾���܂�
     * @return
     */
    public String getRecNo() {
        return _recNo;
    }

    /** 2015/12/9 JASRAC�Ή� HLC K.Soga ADD Start */
    /**
     * 10��CM�R�[�h��ݒ肵�܂�
     * @param val
     */
    public void setCmCd(String val) {
        _cmCd = val;
    }

    /**
     * 10��CM�R�[�h���擾���܂�
     * @return
     */
    public String getCmCd() {
        return _cmCd;
    }

    /**
     * ��10��CM�R�[�h��ݒ肵�܂�
     * @param val
     */
    public void setTempCmCd(String val) {
        _tempCmCd = val;
    }

    /**
     * ��10��CM�R�[�h���擾���܂�
     * @return
     */
    public String getTempCmCd() {
        return _tempCmCd;
    }

    /**
     * �^�C�g����ݒ肵�܂�
     * @param val
     */
    public void setTitle(String val) {
        _title = val;
    }

    /**
     * �^�C�g�����擾���܂�
     * @return
     */
    public String getTitle() {
        return _title;
    }
    /** 2015/12/9 JASRAC�Ή� HLC K.Soga ADD End */

    /** 2016/04/12 HDX�Ή� HLC K.Soga ADD Start */
    /**
     * �f�ޓo�^�f�[�^�̑S���\����ݒ肵�܂�
     * @param val
     */
    public void setDispAllList(boolean val) {
        _dispAllList = val;
    }

    /**
     * �f�ޓo�^�f�[�^�̑S���\�����擾���܂�
     * @return
     */
    public boolean getDispAllList() {
        return _dispAllList;
    }

    /**
     * �Ώ۔N����ݒ肵�܂�
     * @param val �Ώ۔N��
     */
    public void setDispAllListYmDate(String val) {
        _dispAllListYmDate = val;
    }

    /**
     * �Ώ۔N�����擾���܂�
     * @return �Ώ۔N��
     */
    public String getDispAllListYmDate() {
        return _dispAllListYmDate;
    }
    /** 2016/04/12 HDX�Ή� HLC K.Soga ADD End */
}
