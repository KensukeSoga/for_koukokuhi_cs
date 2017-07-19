package jp.co.isid.ham.mastermaintenance.model;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * �Ԏ�S��(�f��)�\�����Result
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2016/02/17 HLC K.Oki)<BR>
 * </P>
 * @author K.Oki
 */
@XmlRootElement(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
@XmlType(namespace = "http://model.mastermaintenance.ham.isid.co.jp/")
public class FindMasterMaintenanceCarUserSozaiDispResult extends AbstractServiceResult
{
    /** �Ԏ�S��(�f��)�X�v���b�h�����f�[�^VO */
    private FindMasterMaintenanceCarUserSozaiSpreadVO _carUserSozaiSpreadVO = null;
    /** �Ԏ팟���f�[�^VO */
    private FindMbj05CarVO _carVo = null;
    /** �Z�L�����e�B�O���[�v���[�U�[(HC/HM)�����f�[�^VO */
    private FindMasterMaintenanceHCHMSecGrpUserSpreadVO _HCHMSecGrpUserSpreadVO = null;


    /**
     * �Ԏ�S��(�f��)�X�v���b�h�����f�[�^VO��ݒ肵�܂�
     * @param vo �Z�b�g���� _carUserSozaiSpreadVO
     */
    public void setCarUserSozaiSpreadVO(FindMasterMaintenanceCarUserSozaiSpreadVO vo)
    {
        _carUserSozaiSpreadVO = vo;
    }

    /**
     * �Ԏ�S��(�f��)�X�v���b�h�����f�[�^VO���擾���܂�
     * @return _carUserSozaiSpreadVO
     */
    public FindMasterMaintenanceCarUserSozaiSpreadVO getCarUserSozaiSpreadVO()
    {
        return _carUserSozaiSpreadVO;
    }

    /**
     * �Ԏ팟���f�[�^VO��ݒ肵�܂�
     * @param vo �Z�b�g���� _carVO
     */
    public void setCarVO(FindMbj05CarVO vo) {
        _carVo = vo;
    }

    /**
     * �Ԏ팟���f�[�^VO���擾���܂�
     * @return _carVO
     */
    public FindMbj05CarVO getCarVO() {
        return _carVo;
    }
    /**
     * �Z�L�����e�B�O���[�v���[�U�[(HC/HM)�X�v���b�h�����f�[�^VO��ݒ肵�܂�
     * @param vo �Z�b�g���� _HCHMSecGrpUserSpreadVO
     */
    public void setHCHMSecGrpUserSpreadVO(FindMasterMaintenanceHCHMSecGrpUserSpreadVO vo)
    {
        _HCHMSecGrpUserSpreadVO = vo;
    }

    /**
     * �Z�L�����e�B�O���[�v���[�U�[(HC/HM)�X�v���b�h�����f�[�^VO���擾���܂�
     * @return _carUserSozaiSpreadVO
     */
    public FindMasterMaintenanceHCHMSecGrpUserSpreadVO getHCHMSecGrpUserSpreadVO()
    {
        return _HCHMSecGrpUserSpreadVO;
    }

}
