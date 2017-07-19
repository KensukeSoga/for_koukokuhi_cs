package jp.co.isid.ham.common.model;

import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mfk01Kkh;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * ���J�͈̓}�X�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mfk01KkhVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Mfk01KkhVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new Mfk01KkhVO();
    }

    /**
     * �^�C���X�^���v���擾����
     *
     * @return �^�C���X�^���v
     */
    @XmlElement(required = true, nillable = true)
    public Date getTIMSTMP() {
        return (Date) get(Mfk01Kkh.TIMSTMP);
    }

    /**
     * �^�C���X�^���v��ݒ肷��
     *
     * @param val �^�C���X�^���v
     */
    public void setTIMSTMP(Date val) {
        set(Mfk01Kkh.TIMSTMP, val);
    }

    /**
     * �X�V�v���O�������擾����
     *
     * @return �X�V�v���O����
     */
    public String getUPDAPL() {
        return (String) get(Mfk01Kkh.UPDAPL);
    }

    /**
     * �X�V�v���O������ݒ肷��
     *
     * @param val �X�V�v���O����
     */
    public void setUPDAPL(String val) {
        set(Mfk01Kkh.UPDAPL, val);
    }

    /**
     * �X�V�S���҂��擾����
     *
     * @return �X�V�S����
     */
    public String getUPDTNT() {
        return (String) get(Mfk01Kkh.UPDTNT);
    }

    /**
     * �X�V�S���҂�ݒ肷��
     *
     * @param val �X�V�S����
     */
    public void setUPDTNT(String val) {
        set(Mfk01Kkh.UPDTNT, val);
    }

    /**
     * ���j�b�gNo.���擾����
     *
     * @return ���j�b�gNo.
     */
    public String getZSBCH0100() {
        return (String) get(Mfk01Kkh.ZSBCH0100);
    }

    /**
     * ���j�b�gNo.��ݒ肷��
     *
     * @param val ���j�b�gNo.
     */
    public void setZSBCH0100(String val) {
        set(Mfk01Kkh.ZSBCH0100, val);
    }

    /**
     * �L���I�������擾����
     *
     * @return �L���I����
     */
    public String getDATETO() {
        return (String) get(Mfk01Kkh.DATETO);
    }

    /**
     * �L���I������ݒ肷��
     *
     * @param val �L���I����
     */
    public void setDATETO(String val) {
        set(Mfk01Kkh.DATETO, val);
    }

    /**
     * �L���J�n�����擾����
     *
     * @return �L���J�n��
     */
    public String getDATEFROM() {
        return (String) get(Mfk01Kkh.DATEFROM);
    }

    /**
     * �L���J�n����ݒ肷��
     *
     * @param val �L���J�n��
     */
    public void setDATEFROM(String val) {
        set(Mfk01Kkh.DATEFROM, val);
    }

    /**
     * �g�D�R�[�h���擾����
     *
     * @return �g�D�R�[�h
     */
    public String getZSBCH0105() {
        return (String) get(Mfk01Kkh.ZSBCH0105);
    }

    /**
     * �g�D�R�[�h��ݒ肷��
     *
     * @param val �g�D�R�[�h
     */
    public void setZSBCH0105(String val) {
        set(Mfk01Kkh.ZSBCH0105, val);
    }

    /**
     * �͈̓t���O���擾����
     *
     * @return �͈̓t���O
     */
    public String getZHANNIGF() {
        return (String) get(Mfk01Kkh.ZHANNIGF);
    }

    /**
     * �͈̓t���O��ݒ肷��
     *
     * @param val �͈̓t���O
     */
    public void setZHANNIGF(String val) {
        set(Mfk01Kkh.ZHANNIGF, val);
    }

    /**
     * �S���O���[�v���擾����
     *
     * @return �S���O���[�v
     */
    public String getZSBCH0109() {
        return (String) get(Mfk01Kkh.ZSBCH0109);
    }

    /**
     * �S���O���[�v��ݒ肷��
     *
     * @param val �S���O���[�v
     */
    public void setZSBCH0109(String val) {
        set(Mfk01Kkh.ZSBCH0109, val);
    }

    /**
     * �E�ʁE�����O���[�v���擾����
     *
     * @return �E�ʁE�����O���[�v
     */
    public String getZTOUKYU() {
        return (String) get(Mfk01Kkh.ZTOUKYU);
    }

    /**
     * �E�ʁE�����O���[�v��ݒ肷��
     *
     * @param val �E�ʁE�����O���[�v
     */
    public void setZTOUKYU(String val) {
        set(Mfk01Kkh.ZTOUKYU, val);
    }

    /**
     * �Ј��R�[�h���擾����
     *
     * @return �Ј��R�[�h
     */
    public String getZSBCH0110() {
        return (String) get(Mfk01Kkh.ZSBCH0110);
    }

    /**
     * �Ј��R�[�h��ݒ肷��
     *
     * @param val �Ј��R�[�h
     */
    public void setZSBCH0110(String val) {
        set(Mfk01Kkh.ZSBCH0110, val);
    }

    /**
     * �\�Z�Ȗځi�啪�ށj���擾����
     *
     * @return �\�Z�Ȗځi�啪�ށj
     */
    public String getZBACCTL() {
        return (String) get(Mfk01Kkh.ZBACCTL);
    }

    /**
     * �\�Z�Ȗځi�啪�ށj��ݒ肷��
     *
     * @param val �\�Z�Ȗځi�啪�ށj
     */
    public void setZBACCTL(String val) {
        set(Mfk01Kkh.ZBACCTL, val);
    }

    /**
     * �\�Z�Ȗ�(�����ށj���擾����
     *
     * @return �\�Z�Ȗ�(�����ށj
     */
    public String getZBACCTM() {
        return (String) get(Mfk01Kkh.ZBACCTM);
    }

    /**
     * �\�Z�Ȗ�(�����ށj��ݒ肷��
     *
     * @param val �\�Z�Ȗ�(�����ށj
     */
    public void setZBACCTM(String val) {
        set(Mfk01Kkh.ZBACCTM, val);
    }

    /**
     * �\�Z�Ȗ�(�����ށj���擾����
     *
     * @return �\�Z�Ȗ�(�����ށj
     */
    public String getZBACCTS() {
        return (String) get(Mfk01Kkh.ZBACCTS);
    }

    /**
     * �\�Z�Ȗ�(�����ށj��ݒ肷��
     *
     * @param val �\�Z�Ȗ�(�����ށj
     */
    public void setZBACCTS(String val) {
        set(Mfk01Kkh.ZBACCTS, val);
    }

    /**
     * �c�Ɣ�o�^�t���O���擾����
     *
     * @return �c�Ɣ�o�^�t���O
     */
    public String getZEIGYOU() {
        return (String) get(Mfk01Kkh.ZEIGYOU);
    }

    /**
     * �c�Ɣ�o�^�t���O��ݒ肷��
     *
     * @param val �c�Ɣ�o�^�t���O
     */
    public void setZEIGYOU(String val) {
        set(Mfk01Kkh.ZEIGYOU, val);
    }

    /**
     * �s�q�r�o�^�t���O���擾����
     *
     * @return �s�q�r�o�^�t���O
     */
    public String getZTRSFG() {
        return (String) get(Mfk01Kkh.ZTRSFG);
    }

    /**
     * �s�q�r�o�^�t���O��ݒ肷��
     *
     * @param val �s�q�r�o�^�t���O
     */
    public void setZTRSFG(String val) {
        set(Mfk01Kkh.ZTRSFG, val);
    }

    /**
     * PL�Ɖ�t���O���擾����
     *
     * @return PL�Ɖ�t���O
     */
    public String getZPLFG() {
        return (String) get(Mfk01Kkh.ZPLFG);
    }

    /**
     * PL�Ɖ�t���O��ݒ肷��
     *
     * @param val PL�Ɖ�t���O
     */
    public void setZPLFG(String val) {
        set(Mfk01Kkh.ZPLFG, val);
    }

    /**
     * �󔭒��o�^�t���O���擾����
     *
     * @return �󔭒��o�^�t���O
     */
    public String getZJYUHACHU() {
        return (String) get(Mfk01Kkh.ZJYUHACHU);
    }

    /**
     * �󔭒��o�^�t���O��ݒ肷��
     *
     * @param val �󔭒��o�^�t���O
     */
    public void setZJYUHACHU(String val) {
        set(Mfk01Kkh.ZJYUHACHU, val);
    }

    /**
     * �S�����t���O���擾����
     *
     * @return �S�����t���O
     */
    public String getZALLFG() {
        return (String) get(Mfk01Kkh.ZALLFG);
    }

    /**
     * �S�����t���O��ݒ肷��
     *
     * @param val �S�����t���O
     */
    public void setZALLFG(String val) {
        set(Mfk01Kkh.ZALLFG, val);
    }

    /**
     * �p���Ǘ��t���O���擾����
     *
     * @return �p���Ǘ��t���O
     */
    public String getZKEISYOU() {
        return (String) get(Mfk01Kkh.ZKEISYOU);
    }

    /**
     * �p���Ǘ��t���O��ݒ肷��
     *
     * @param val �p���Ǘ��t���O
     */
    public void setZKEISYOU(String val) {
        set(Mfk01Kkh.ZKEISYOU, val);
    }

    /**
     * �_���폜�t���O���擾����
     *
     * @return �_���폜�t���O
     */
    public String getZDELFG() {
        return (String) get(Mfk01Kkh.ZDELFG);
    }

    /**
     * �_���폜�t���O��ݒ肷��
     *
     * @param val �_���폜�t���O
     */
    public void setZDELFG(String val) {
        set(Mfk01Kkh.ZDELFG, val);
    }

    /**
     * ���J�͈̓^�C���X�^���v���擾����
     *
     * @return ���J�͈̓^�C���X�^���v
     */
    public String getKKHTIMESTAMP() {
        return (String) get(Mfk01Kkh.KKHTIMESTAMP);
    }

    /**
     * ���J�͈̓^�C���X�^���v��ݒ肷��
     *
     * @param val ���J�͈̓^�C���X�^���v
     */
    public void setKKHTIMESTAMP(String val) {
        set(Mfk01Kkh.KKHTIMESTAMP, val);
    }

}
