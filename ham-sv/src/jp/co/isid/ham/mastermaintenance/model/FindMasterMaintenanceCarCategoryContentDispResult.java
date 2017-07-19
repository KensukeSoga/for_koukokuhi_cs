package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * �Ԏ�J�e�S���R�t�\�����Result
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2012/12/12 �X)<BR>
 * </P>
 * @author �X
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceCarCategoryContentDispResult extends AbstractServiceResult
{
    /** �Ԏ�J�e�S���R�t�����f�[�^VO */
    private FindMbj22CategoryContentVO _carCategoryContentVO = null;

    /** �Ԏ�J�e�S�������f�[�^VO */
    private FindMbj20CarCategoryVO _carCategoryVO = null;

    /** �Ԏ팟���f�[�^VO */
    private FindMbj05CarVO _carVO = null;

    /**
     * �Ԏ�J�e�S���R�t�����f�[�^VO��ݒ肵�܂�
     * @param vo �Z�b�g���� _carCategoryContentVO
     */
    public void setCarCategoryContentVO(FindMbj22CategoryContentVO vo)
    {
        _carCategoryContentVO = vo;
    }

    /**
     * �Ԏ�J�e�S���R�t�����f�[�^VO���擾���܂�
     * @return _carCategoryContentVO
     */
    public FindMbj22CategoryContentVO getCarCategoryContentVO()
    {
        return _carCategoryContentVO;
    }

    /**
     * �Ԏ�J�e�S�������f�[�^VO��ݒ肵�܂�
     * @param vo �Z�b�g���� _carCategoryVO
     */
    public void setCarCategoryVO(FindMbj20CarCategoryVO vo)
    {
        _carCategoryVO = vo;
    }

    /**
     * �Ԏ�J�e�S�������f�[�^VO���擾���܂�
     * @return _carCategoryVO
     */
    public FindMbj20CarCategoryVO getCarCategoryVO()
    {
        return _carCategoryVO;
    }

    /**
     * �Ԏ팟���f�[�^VO��ݒ肵�܂�
     * @param vo �Z�b�g���� _carVO
     */
    public void setCarVO(FindMbj05CarVO vo)
    {
        _carVO = vo;
    }

    /**
     * �Ԏ팟���f�[�^VO���擾���܂�
     * @return _carVO
     */
    public FindMbj05CarVO getCarVO()
    {
        return _carVO;
    }

}
