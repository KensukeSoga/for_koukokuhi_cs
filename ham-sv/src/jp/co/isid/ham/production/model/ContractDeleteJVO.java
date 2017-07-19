package jp.co.isid.ham.production.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * �폜�{�^����������JASRAC�J�E���g�擾VO
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/14 �VHAM�`�[��)<BR>
 * </P>
 * @author �VHAM�`�[��
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class ContractDeleteJVO extends AbstractModel {

    /** serialVersionUID */
    private static final long serialVersionUID = 1L;

//    /**
//     * �_��R�[�h
//     */
//    private String _CTRTNO = null;

    /**
     * �J�E���g
     */
    private int _COUNT = 0;

    /**
     * �f�t�H���g�R���X�g���N�^
     */
    public ContractDeleteJVO() {
        //�X�[�p�[�N���X�̃R���X�g���N�^���Ăяo��
        super();
    }

    /**
     * �V�K�C���X�^���X�𐶐�����
     *
     * @return �V�K�C���X�^���X
     */
    public Object newInstance() {
        return new ContractDeleteJVO();
    }

//    /**
//     * �_��R�[�h���擾����
//     *
//     * @return �_��R�[�h
//     */
//    public String getCTRTNO() {
//        return _CTRTNO;
//    }
//
//    /**
//     * �_��R�[�h��ݒ肷��
//     *
//     * @param val �_��R�[�h
//     */
//    public void setCTRTNO(String val) {
//        _CTRTNO = val;
//    }

    /**
     * �J�E���g���擾����
     *
     * @return �J�E���g
     */
    public int getCOUNT() {
        return _COUNT;
    }

    /**
     * �J�E���g��ݒ肷��
     *
     * @param val �J�E���g
     */
    public void setCOUNT(int val) {
        _COUNT = val;
    }

}
