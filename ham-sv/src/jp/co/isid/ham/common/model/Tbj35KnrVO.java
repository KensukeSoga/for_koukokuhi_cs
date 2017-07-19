package jp.co.isid.ham.common.model;

import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj35Knr;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �Ǘ��e�[�u��VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Tbj35KnrVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Tbj35KnrVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new Tbj35KnrVO();
    }

    /**
     * �V�X�e��NO���擾����
     *
     * @return �V�X�e��NO
     */
    public String getSYSTEMNO() {
        return (String) get(Tbj35Knr.SYSTEMNO);
    }

    /**
     * �V�X�e��NO��ݒ肷��
     *
     * @param val �V�X�e��NO
     */
    public void setSYSTEMNO(String val) {
        set(Tbj35Knr.SYSTEMNO, val);
    }

    /**
     * �V�X�e�����̂��擾����
     *
     * @return �V�X�e������
     */
    public String getSYSTEMNAME() {
        return (String) get(Tbj35Knr.SYSTEMNAME);
    }

    /**
     * �V�X�e�����̂�ݒ肷��
     *
     * @param val �V�X�e������
     */
    public void setSYSTEMNAME(String val) {
        set(Tbj35Knr.SYSTEMNAME, val);
    }

    /**
     * �Ǘ��t���O���擾����
     *
     * @return �Ǘ��t���O
     */
    public String getKANRIFLG() {
        return (String) get(Tbj35Knr.KANRIFLG);
    }

    /**
     * �Ǘ��t���O��ݒ肷��
     *
     * @param val �Ǘ��t���O
     */
    public void setKANRIFLG(String val) {
        set(Tbj35Knr.KANRIFLG, val);
    }

    /**
     * ���p�\�J�n�j���敪���擾����
     *
     * @return ���p�\�J�n�j���敪
     */
    public String getRSTAYOKBN() {
        return (String) get(Tbj35Knr.RSTAYOKBN);
    }

    /**
     * ���p�\�J�n�j���敪��ݒ肷��
     *
     * @param val ���p�\�J�n�j���敪
     */
    public void setRSTAYOKBN(String val) {
        set(Tbj35Knr.RSTAYOKBN, val);
    }

    /**
     * ���p�\�I���j���敪���擾����
     *
     * @return ���p�\�I���j���敪
     */
    public String getRENDYOKBN() {
        return (String) get(Tbj35Knr.RENDYOKBN);
    }

    /**
     * ���p�\�I���j���敪��ݒ肷��
     *
     * @param val ���p�\�I���j���敪
     */
    public void setRENDYOKBN(String val) {
        set(Tbj35Knr.RENDYOKBN, val);
    }

    /**
     * ���p�\���t�ύX�敪���擾����
     *
     * @return ���p�\���t�ύX�敪
     */
    public String getDAYCHGKBN() {
        return (String) get(Tbj35Knr.DAYCHGKBN);
    }

    /**
     * ���p�\���t�ύX�敪��ݒ肷��
     *
     * @param val ���p�\���t�ύX�敪
     */
    public void setDAYCHGKBN(String val) {
        set(Tbj35Knr.DAYCHGKBN, val);
    }

    /**
     * ���p�\�J�n���Ԃ��擾����
     *
     * @return ���p�\�J�n����
     */
    public String getRSTARTTIME() {
        return (String) get(Tbj35Knr.RSTARTTIME);
    }

    /**
     * ���p�\�J�n���Ԃ�ݒ肷��
     *
     * @param val ���p�\�J�n����
     */
    public void setRSTARTTIME(String val) {
        set(Tbj35Knr.RSTARTTIME, val);
    }

    /**
     * ���p�\�I�����Ԃ��擾����
     *
     * @return ���p�\�I������
     */
    public String getRENDTIME() {
        return (String) get(Tbj35Knr.RENDTIME);
    }

    /**
     * ���p�\�I�����Ԃ�ݒ肷��
     *
     * @param val ���p�\�I������
     */
    public void setRENDTIME(String val) {
        set(Tbj35Knr.RENDTIME, val);
    }

    /**
     * �c�Ɠ����擾����
     *
     * @return �c�Ɠ�
     */
    public String getEIGYOBI() {
        return (String) get(Tbj35Knr.EIGYOBI);
    }

    /**
     * �c�Ɠ���ݒ肷��
     *
     * @param val �c�Ɠ�
     */
    public void setEIGYOBI(String val) {
        set(Tbj35Knr.EIGYOBI, val);
    }

    /**
     * ���b�Z�[�W�P���擾����
     *
     * @return ���b�Z�[�W�P
     */
    public String getMSG01() {
        return (String) get(Tbj35Knr.MSG01);
    }

    /**
     * ���b�Z�[�W�P��ݒ肷��
     *
     * @param val ���b�Z�[�W�P
     */
    public void setMSG01(String val) {
        set(Tbj35Knr.MSG01, val);
    }

    /**
     * ���b�Z�[�W�Q���擾����
     *
     * @return ���b�Z�[�W�Q
     */
    public String getMSG02() {
        return (String) get(Tbj35Knr.MSG02);
    }

    /**
     * ���b�Z�[�W�Q��ݒ肷��
     *
     * @param val ���b�Z�[�W�Q
     */
    public void setMSG02(String val) {
        set(Tbj35Knr.MSG02, val);
    }

    /**
     * ���b�Z�[�W�R���擾����
     *
     * @return ���b�Z�[�W�R
     */
    public String getMSG03() {
        return (String) get(Tbj35Knr.MSG03);
    }

    /**
     * ���b�Z�[�W�R��ݒ肷��
     *
     * @param val ���b�Z�[�W�R
     */
    public void setMSG03(String val) {
        set(Tbj35Knr.MSG03, val);
    }

    /**
     * ���b�Z�[�W�S���擾����
     *
     * @return ���b�Z�[�W�S
     */
    public String getMSG04() {
        return (String) get(Tbj35Knr.MSG04);
    }

    /**
     * ���b�Z�[�W�S��ݒ肷��
     *
     * @param val ���b�Z�[�W�S
     */
    public void setMSG04(String val) {
        set(Tbj35Knr.MSG04, val);
    }

    /**
     * ���b�Z�[�W�T���擾����
     *
     * @return ���b�Z�[�W�T
     */
    public String getMSG05() {
        return (String) get(Tbj35Knr.MSG05);
    }

    /**
     * ���b�Z�[�W�T��ݒ肷��
     *
     * @param val ���b�Z�[�W�T
     */
    public void setMSG05(String val) {
        set(Tbj35Knr.MSG05, val);
    }

    /**
     * ���l���擾����
     *
     * @return ���l
     */
    public String getBIKOU() {
        return (String) get(Tbj35Knr.BIKOU);
    }

    /**
     * ���l��ݒ肷��
     *
     * @param val ���l
     */
    public void setBIKOU(String val) {
        set(Tbj35Knr.BIKOU, val);
    }

    /**
     * �\���敪���擾����
     *
     * @return �\���敪
     */
    public String getHYOUJIKBN() {
        return (String) get(Tbj35Knr.HYOUJIKBN);
    }

    /**
     * �\���敪��ݒ肷��
     *
     * @param val �\���敪
     */
    public void setHYOUJIKBN(String val) {
        set(Tbj35Knr.HYOUJIKBN, val);
    }

    /**
     * �o�b�`����t���O���擾����
     *
     * @return �o�b�`����t���O
     */
    public String getBATCHFLG() {
        return (String) get(Tbj35Knr.BATCHFLG);
    }

    /**
     * �o�b�`����t���O��ݒ肷��
     *
     * @param val �o�b�`����t���O
     */
    public void setBATCHFLG(String val) {
        set(Tbj35Knr.BATCHFLG, val);
    }

    /**
     * �f�[�^�X�V�������擾����
     *
     * @return �f�[�^�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Tbj35Knr.UPDDATE);
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     *
     * @param val �f�[�^�X�V����
     */
    public void setUPDDATE(Date val) {
        set(Tbj35Knr.UPDDATE, val);
    }

    /**
     * �f�[�^�X�V�҂��擾����
     *
     * @return �f�[�^�X�V��
     */
    public String getUPDNM() {
        return (String) get(Tbj35Knr.UPDNM);
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     *
     * @param val �f�[�^�X�V��
     */
    public void setUPDNM(String val) {
        set(Tbj35Knr.UPDNM, val);
    }

    /**
     * �X�V�v���O�������擾����
     *
     * @return �X�V�v���O����
     */
    public String getUPDAPL() {
        return (String) get(Tbj35Knr.UPDAPL);
    }

    /**
     * �X�V�v���O������ݒ肷��
     *
     * @param val �X�V�v���O����
     */
    public void setUPDAPL(String val) {
        set(Tbj35Knr.UPDAPL, val);
    }

    /**
     * �X�V�S����ID���擾����
     *
     * @return �X�V�S����ID
     */
    public String getUPDID() {
        return (String) get(Tbj35Knr.UPDID);
    }

    /**
     * �X�V�S����ID��ݒ肷��
     *
     * @param val �X�V�S����ID
     */
    public void setUPDID(String val) {
        set(Tbj35Knr.UPDID, val);
    }

}
