package jp.co.isid.ham.common.model;

import java.io.Serializable;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 * <P>
 * �@�\���䌟������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/17 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class StartUpCondition implements Serializable {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /** �R�[�h���(�t�F�C�Y) */
    private String _codetypephase = null;

    /** �R�[�h���(���[�f�B���N�g��) */
    private String _codetypereport = null;

    /** ���[�U�� */
    private String _usernm = null;

    /** �S����ID */
    private String _hamid = null;

    /** �X�V�v���O���� */
    private String _updapl = null;

    /** �g�D�R�[�h */
    private String _sikcd = null;

    /** ���� */
    private String _affiliation = null;

    /** ���O�C�������쐬���邩�ǂ��� */
    private boolean _createLoginInfo = false;

    /**
     * �R�[�h���(�t�F�C�Y)���擾����
     *
     * @return �R�[�h���
     */
    public String getCodetypePhase() {
        return _codetypephase;
    }

    /**
     * �R�[�h���(�t�F�C�Y)��ݒ肷��
     *
     * @param codetype �R�[�h���
     */
    public void setCodetypePhase(String codetype) {
        this._codetypephase = codetype;
    }

    /**
     * �R�[�h���(���[)���擾����
     *
     * @return �R�[�h���
     */
    public String getCodetypeReport() {
        return _codetypereport;
    }

    /**
     * �R�[�h���(���[)��ݒ肷��
     *
     * @param codetype �R�[�h���
     */
    public void setCodetypeReport(String codetype) {
        this._codetypereport = codetype;
    }

    /**
     * ���[�U�[�����擾����
     *
     * @return ���[�U�[��
     */
    public String getUserNm() {
        return _usernm;
    }

    /**
     * ���[�U�[����ݒ肷��
     *
     * @param usernm ���[�U�[��
     */
    public void setUserNm(String usernm) {
        _usernm = usernm;
    }

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
     * �X�V�v���O�������擾����
     *
     * @return �X�V�v���O����
     */
    public String getUpdapl() {
        return _updapl;
    }

    /**
     * �X�V�v���O������ݒ肷��
     *
     * @param updapl �X�V�v���O����
     */
    public void setUpdapl(String updapl) {
        this._updapl = updapl;
    }

    /**
     * �g�D�R�[�h���擾����
     *
     * @return �g�D�R�[�h
     */
    public String getSikcd() {
        return _sikcd;
    }

    /**
     * �g�D�R�[�h��ݒ肷��
     *
     * @param sikcd �g�D�R�[�h
     */
    public void setSikcd(String sikcd) {
        _sikcd = sikcd;
    }

    /**
     * �������擾����
     *
     * @return ����
     */
    public String getAffiliation() {
        return _affiliation;
    }

    /**
     * ������ݒ肷��
     *
     * @param affiliation ����
     */
    public void setAffiliation(String affiliation) {
        _affiliation = affiliation;
    }

    /**
     * ���O�C�������쐬���邩�ǂ������擾����
     *
     * @return ���O�C�������쐬���邩�ǂ���
     */
    public boolean getCreateLoginInfo() {
        return _createLoginInfo;
    }

    /**
     * ���O�C�������쐬���邩�ǂ�����ݒ肷��
     *
     * @param createdLoginInfo ���O�C�������쐬���邩�ǂ���
     */
    public void setCreateLoginInfo(boolean createLoginInfo) {
        _createLoginInfo = createLoginInfo;
    }
}
