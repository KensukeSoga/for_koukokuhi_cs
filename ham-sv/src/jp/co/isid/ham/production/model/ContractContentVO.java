package jp.co.isid.ham.production.model;

import jp.co.isid.nj.model.AbstractModel;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Tbj16ContractInfo;
import jp.co.isid.ham.integ.tbl.Tbj17Content;

/**
 * <P>
 * �_����o�^�o�^�{�^���������擾�f�[�^�ێ��N���X
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/18 �VHAM�`�[��)<BR>
 * </P>
 *
 * @author �VHAM�`�[��
 */

@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class ContractContentVO extends AbstractModel {

    /**
     *
     */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public ContractContentVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new ContentMaterialVO();
    }

    /**
     * �_�����(From)���擾����
     *
     * @return �_�����(From)
     */
    public String getDATEFROM() {
        return (String) get(Tbj16ContractInfo.DATEFROM);
    }

    /**
     * �_�����(From)��ݒ肷��
     *
     * @param val �_�����(From)
     */
    public void setDATEFROM(String val) {
        set(Tbj16ContractInfo.DATEFROM, val);
    }

    /**
     * �_�����(To)��ݒ肷��
     *
     * @param val �_�����(To)
     */
    public void setDATETO(String val) {
        set(Tbj16ContractInfo.DATETO, val);
    }

    /**
     * �_�����(To)���擾����
     *
     * @return �_�����(To)
     */
    public String getDATETO() {
        return (String) get(Tbj16ContractInfo.DATETO);
    }

    /**
     * �l���A�A�[�e�B�X�g��ݒ肷��
     *
     * @param val �l���A�A�[�e�B�X�g
     */
    public void setNAMES(String val) {
        set(Tbj16ContractInfo.NAMES, val);
    }

    /**
     * �l���A�A�[�e�B�X�g���擾����
     *
     * @return �l���A�A�[�e�B�X�g
     */
    public String getNAMES() {
        return (String) get(Tbj16ContractInfo.NAMES);
    }

    /**
     * �y�Ȃ�ݒ肷��
     *
     * @param val �y��
     */
    public void setMUSIC(String val) {
        set(Tbj16ContractInfo.MUSIC, val);
    }

    /**
     * �y�Ȃ��擾����
     *
     * @return �y��
     */
    public String getMUSIC() {
        return (String) get(Tbj16ContractInfo.MUSIC);
    }

    /**
     * 10��CM���ނ��擾����
     *
     * @return 10��CM����
     */
    public String getCMCD() {
        return (String) get(Tbj17Content.CMCD);
    }

    /**
     * 10��CM���ނ�ݒ肷��
     *
     * @param val 10��CM����
     */
    public void getCMCD(String val) {
        set(Tbj17Content.CMCD, val);
    }

    /**
     * �폜�t���O��ݒ肷��
     *
     * @param val �폜�t���O
     */
    public void setDELFLG(String val) {
        set(Tbj16ContractInfo.DELFLG, val);
    }

    /**
     * �폜�t���O���擾����
     *
     * @return �폜�t���O
     */
    public String getDELFLG() {
        return (String) get(Tbj16ContractInfo.DELFLG);
    }

    /**
     * �_����(�R���e���c�e�[�u��)���擾����
     *
     * @return �_����
     */
    public String getCTRTKBN() {
        return (String) get(Tbj17Content.CTRTKBN);
    }

    /**
     * �_����(�R���e���c�e�[�u��)��ݒ肷��
     *
     * @param val �_����
     */
    public void setCTRTKBN(String val) {
        set(Tbj17Content.CTRTKBN, val);
    }
    /**
     * �_����(�_����e�[�u��)���擾����
     *
     * @return �_����
     */
    public String getCONTRACTCTRTKBN() {
        return (String) get(Tbj16ContractInfo.CTRTKBN);
    }

    /**
     * �_����(�_����e�[�u��)��ݒ肷��
     *
     * @param val �_����
     */
    public void setCONTRACTCTRTKBN(String val) {
        set(Tbj16ContractInfo.CTRTKBN, val);
    }

    /**
     * �_��R�[�h(�R���e���c�e�[�u��)���擾����
     *
     * @return �_��R�[�h
     */
    public String getCTRTNO() {
        return (String) get(Tbj17Content.CTRTNO);
    }

    /**
     * �_��R�[�h(�R���e���c�e�[�u��)��ݒ肷��
     *
     * @param val �_��R�[�h
     */
    public void setCTRTNO(String val) {
        set(Tbj17Content.CTRTNO, val);
    }

    /**
     * �_��R�[�h(�_����e�[�u��)���擾����
     *
     * @return �_��R�[�h
     */
    public String getCONTRACTCTRTNO() {
        return (String) get(Tbj16ContractInfo.CTRTNO);
    }

    /**
     * �_��R�[�h(�_����e�[�u��)��ݒ肷��
     *
     * @param val �_��R�[�h
     */
    public void setCONTRACTCTRTNO(String val) {
        set(Tbj16ContractInfo.CTRTNO, val);
    }
}
