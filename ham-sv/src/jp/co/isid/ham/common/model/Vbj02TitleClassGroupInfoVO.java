package jp.co.isid.ham.common.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.integ.tbl.Vbj02TitleClassGroupInfo;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �VHAM����VIEW(�E�ʓ����O���[�v���)VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/11/29 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.common.ham.isid.co.jp/")
@XmlType(namespace = "http://model.common.ham.isid.co.jp/")
public class Vbj02TitleClassGroupInfoVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public Vbj02TitleClassGroupInfoVO() {
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new Vbj02TitleClassGroupInfoVO();
    }

    /**
     * �O���[�v�R�[�h���擾����
     *
     * @return �O���[�v�R�[�h
     */
    public String getGROUPCD() {
        return (String) get(Vbj02TitleClassGroupInfo.GROUPCD);
    }

    /**
     * �O���[�v�R�[�h��ݒ肷��
     *
     * @param val �O���[�v�R�[�h
     */
    public void setGROUPCD(String val) {
        set(Vbj02TitleClassGroupInfo.GROUPCD, val);
    }

    /**
     * �O���[�v���̊������擾����
     *
     * @return �O���[�v���̊���
     */
    public String getGROUPNMKJ() {
        return (String) get(Vbj02TitleClassGroupInfo.GROUPNMKJ);
    }

    /**
     * �O���[�v���̊�����ݒ肷��
     *
     * @param val �O���[�v���̊���
     */
    public void setGROUPNMKJ(String val) {
        set(Vbj02TitleClassGroupInfo.GROUPNMKJ, val);
    }

    /**
     * �O���[�v���̃A���t�@�x�b�g���擾����
     *
     * @return �O���[�v���̃A���t�@�x�b�g
     */
    public String getGROUPNMALPH() {
        return (String) get(Vbj02TitleClassGroupInfo.GROUPNMALPH);
    }

    /**
     * �O���[�v���̃A���t�@�x�b�g��ݒ肷��
     *
     * @param val �O���[�v���̃A���t�@�x�b�g
     */
    public void setGROUPNMALPH(String val) {
        set(Vbj02TitleClassGroupInfo.GROUPNMALPH, val);
    }

    /**
     * �J�n�N�������擾����
     *
     * @return �J�n�N����
     */
    public String getSTRTYMD() {
        return (String) get(Vbj02TitleClassGroupInfo.STRTYMD);
    }

    /**
     * �J�n�N������ݒ肷��
     *
     * @param val �J�n�N����
     */
    public void setSTRTYMD(String val) {
        set(Vbj02TitleClassGroupInfo.STRTYMD, val);
    }

    /**
     * �I���N�������擾����
     *
     * @return �I���N����
     */
    public String getSTPYMD() {
        return (String) get(Vbj02TitleClassGroupInfo.STPYMD);
    }

    /**
     * �I���N������ݒ肷��
     *
     * @param val �I���N����
     */
    public void setSTPYMD(String val) {
        set(Vbj02TitleClassGroupInfo.STPYMD, val);
    }

}
