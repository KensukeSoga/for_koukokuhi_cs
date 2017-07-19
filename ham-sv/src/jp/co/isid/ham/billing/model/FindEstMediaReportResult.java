package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.common.model.Mbj12CodeVO;
import jp.co.isid.ham.common.model.Mbj21CalendarVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * ���ρA����CSV�t�@�C���쐬(�}��)��������
 * </P>
 * <P>
 * <B>�C������</B><BR>
 * �E�V�K�쐬(2013/5/8 T.Fujiyoshi)<BR>
 * �E�����Ɩ��ύX�Ή�(2015/08/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindEstMediaReportResult extends AbstractServiceResult {

    /** ���ψČ�/���ϖ��� */
    private List<FindEstItemDtlVO> _estItemDtl;

    /* 2015/08/31 �����Ɩ��ύX�Ή� S.Fujimoto Add Start */
    /** ��Џ�� */
    private List<Mbj12CodeVO> _companyInfo;
    /** �d������Ōv�Z�敪 */
    private List<Mbj12CodeVO> _calKbn;
    /** �J�����_�[�}�X�^ */
    private List<Mbj21CalendarVO> _calendar;
    /* 2015/08/31 �����Ɩ��ύX�Ή� S.Fujimoto Add End */

    /**
     * ���ψČ�/���ϖ��ׂ��擾����
     * @return ���ψČ�/���ϖ���
     */
    public List<FindEstItemDtlVO> getEstItemDtl() {
        return _estItemDtl;
    }

    /**
     * ���ψČ�/���ϖ��ׂ�ݒ肷��
     * @param estItemDtl ���ψČ�/���ϖ���
     */
    public void setEstItemDtl(List<FindEstItemDtlVO> estItemDtl) {
        _estItemDtl = estItemDtl;
    }

    /* 2015/08/31 �����Ɩ��ύX�Ή� S.Fujimoto Add Start */
    /**
     * ��Џ����擾����
     * @return List<Mbj12CodeVO> ��Џ��
     */
    public List<Mbj12CodeVO> getCompanyInfo() {
        return _companyInfo;
    }

    /**
     * ��Џ���ݒ肷��
     * @param vo List<Mbj12CodeVO> ��Џ��
     */
    public void setCompanyInfo(List<Mbj12CodeVO> vo) {
        _companyInfo = vo;
    }

    /**
     * �d������Ōv�Z�敪���擾����
     * @return List<Mbj12CodeVO> �d������Ōv�Z�敪
     */
    public List<Mbj12CodeVO> getCalKbn() {
        return _calKbn;
    }

    /**
     * �d������Ōv�Z�敪��ݒ肷��
     * @param vo List<Mbj12CodeVO> �d������Ōv�Z�敪
     */
    public void setCalKbn(List<Mbj12CodeVO> vo) {
        _calKbn = vo;
    }

    /**
     * �J�����_�[�}�X�^���擾����
     * @return List<Mbj21CalendarVO> �J�����_�[�}�X�^
     */
    public List<Mbj21CalendarVO> getCalendar() {
        return _calendar;
    }

    /**
     * �J�����_�[�}�X�^��ݒ肷��
     * @param vo List<Mbj21CalendarVO> �J�����_�[�}�X�^
     */
    public void setCalendar(List<Mbj21CalendarVO> vo) {
        _calendar = vo;
    }
    /* 2015/08/31 �����Ɩ��ύX�Ή� S.Fujimoto Add End */

}
