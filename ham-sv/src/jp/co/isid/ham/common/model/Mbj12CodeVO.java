package jp.co.isid.ham.common.model;

import java.util.Date;

import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Mbj12Code;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �R�[�h�}�X�^VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Mbj12CodeVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Mbj12CodeVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new Mbj12CodeVO();
    }

    /**
     * �R�[�h��ʂ��擾����
     *
     * @return �R�[�h���
     */
    public String getCODETYPE() {
        return (String) get(Mbj12Code.CODETYPE);
    }

    /**
     * �R�[�h��ʂ�ݒ肷��
     *
     * @param val �R�[�h���
     */
    public void setCODETYPE(String val) {
        set(Mbj12Code.CODETYPE, val);
    }

    /**
     * �L�[�R�[�h���擾����
     *
     * @return �L�[�R�[�h
     */
    public String getKEYCODE() {
        return (String) get(Mbj12Code.KEYCODE);
    }

    /**
     * �L�[�R�[�h��ݒ肷��
     *
     * @param val �L�[�R�[�h
     */
    public void setKEYCODE(String val) {
        set(Mbj12Code.KEYCODE, val);
    }

    /**
     * ����(����)���擾����
     *
     * @return ����(����)
     */
    public String getCODENAME() {
        return (String) get(Mbj12Code.CODENAME);
    }

    /**
     * ����(����)��ݒ肷��
     *
     * @param val ����(����)
     */
    public void setCODENAME(String val) {
        set(Mbj12Code.CODENAME, val);
    }

    /**
     * �\���t�B�[���h1���擾����
     *
     * @return �\���t�B�[���h1
     */
    public String getYOBI1() {
        return (String) get(Mbj12Code.YOBI1);
    }

    /**
     * �\���t�B�[���h1��ݒ肷��
     *
     * @param val �\���t�B�[���h1
     */
    public void setYOBI1(String val) {
        set(Mbj12Code.YOBI1, val);
    }

    /**
     * �\���t�B�[���h2���擾����
     *
     * @return �\���t�B�[���h2
     */
    public String getYOBI2() {
        return (String) get(Mbj12Code.YOBI2);
    }

    /**
     * �\���t�B�[���h2��ݒ肷��
     *
     * @param val �\���t�B�[���h2
     */
    public void setYOBI2(String val) {
        set(Mbj12Code.YOBI2, val);
    }

    /**
     * �\���t�B�[���h3���擾����
     *
     * @return �\���t�B�[���h3
     */
    public String getYOBI3() {
        return (String) get(Mbj12Code.YOBI3);
    }

    /**
     * �\���t�B�[���h3��ݒ肷��
     *
     * @param val �\���t�B�[���h3
     */
    public void setYOBI3(String val) {
        set(Mbj12Code.YOBI3, val);
    }

    /**
     * �f�[�^�X�V�������擾����
     *
     * @return �f�[�^�X�V����
     */
    @XmlElement(required = true, nillable = true)
    public Date getUPDDATE() {
        return (Date) get(Mbj12Code.UPDDATE);
    }

    /**
     * �f�[�^�X�V������ݒ肷��
     *
     * @param val �f�[�^�X�V����
     */
    public void setUPDDATE(Date val) {
        set(Mbj12Code.UPDDATE, val);
    }

    /**
     * �f�[�^�X�V�҂��擾����
     *
     * @return �f�[�^�X�V��
     */
    public String getUPDNM() {
        return (String) get(Mbj12Code.UPDNM);
    }

    /**
     * �f�[�^�X�V�҂�ݒ肷��
     *
     * @param val �f�[�^�X�V��
     */
    public void setUPDNM(String val) {
        set(Mbj12Code.UPDNM, val);
    }

    /**
     * �X�V�S����ID���擾����
     *
     * @return �X�V�S����ID
     */
    public String getUPDID() {
        return (String) get(Mbj12Code.UPDID);
    }

    /**
     * �X�V�S����ID��ݒ肷��
     *
     * @param val �X�V�S����ID
     */
    public void setUPDID(String val) {
        set(Mbj12Code.UPDID, val);
    }

}
